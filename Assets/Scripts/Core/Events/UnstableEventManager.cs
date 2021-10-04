using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
namespace ChaoticDonutFallRampage.Core.Events
{
    public class UnstableEventManager : MonoBehaviour
    {
        public GameObject platform;
        public GameObject controllableModel;
        public GameObject[] fallingObjects;
        protected virtual UnstableEvent CurrentEvent { get; set; }
        protected virtual List<UnstableEvent> Events { get; } = new List<UnstableEvent>();
        protected virtual float Timer { get; set; }
        public float duration = 5f;
        public UnityEngine.UI.Text text;
        protected void Start()
        {
            Timer = duration;
            //text = new UnityEngine.UI.Text();
            //Events.Add(new RotatePlatformUnstableEvent() { platform = platform });
            Events.Add(new UnstableEvent());
            //Events.Add(new ReversedControllsUnstableEvent() { controllableModels = new GameObject[] {controllableModel } });
            //Events.Add(new ChangeGravityUnstableEvent() { controllableModels = new GameObject[] {controllableModel } });
            Events.Add(new ItemRainUnstableEvent() { fallingObjects = fallingObjects, platform = platform });
            CurrentEvent = new UnstableEvent();
        }
        protected virtual UnstableEvent GetNewUnstableEvent()
        {
            if (Events?.Count<2)
            {
                return Events?.FirstOrDefault();
            }
            while (true)
            {
                var desiredEvent = Events?.ElementAtOrDefault(UnityEngine.Random.Range(0, Events?.Count() ?? 0));
                if (desiredEvent != CurrentEvent)
                {
                    return desiredEvent;
                }
            }
        }
        
        protected void Update()
        {
            Timer -= Time.deltaTime;
            text.text = ((int)Timer).ToString();
            if (Timer > 0)
            {
                if (CurrentEvent is UpdatableUnstableEvent uue)
                {
                    uue?.UpdateEventEffect();
                }
                else if (CurrentEvent is ItemRainUnstableEvent irue &&
                    irue.objAm > 0 &&
                    Timer < irue.objsSpawnTime[irue.objAm - 1])
                {
                    Instantiate(
                        original: fallingObjects.ElementAtOrDefault(UnityEngine.Random.Range(0, fallingObjects.Length)),
                        position: new Vector3(platform.transform.position.x + UnityEngine.Random.Range(-irue.spawnRange, irue.spawnRange), platform.transform.position.y + irue.spawnHeight, platform.transform.position.z + UnityEngine.Random.Range(-irue.spawnRange, irue.spawnRange)),
                        rotation: Quaternion.identity
                    );
                    irue.objAm--;
                }
            }
            else
            {
                if (CurrentEvent is StartEndUnstableEvent prevSEUE)
                {
                    prevSEUE?.End();
                }
                Timer = duration;
                CurrentEvent = GetNewUnstableEvent();
                if (CurrentEvent is StartEndUnstableEvent newSEUE)
                {
                    newSEUE?.Start();
                    if (CurrentEvent is ItemRainUnstableEvent irue)
                    {
                        irue.objsSpawnTime = new float[irue.objAm];
                        float spawnDiff = duration / irue.objAm;
                        for (int i = 1; i < irue.objsSpawnTime.Length; i++)
                        {
                            irue.objsSpawnTime[i] = irue.objsSpawnTime[i - 1] + spawnDiff;
                        }
                    }
                }
            }
        }
    }
}
