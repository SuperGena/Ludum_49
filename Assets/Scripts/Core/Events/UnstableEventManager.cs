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
        protected virtual UnstableEvent CurrentEvent { get; set; }
        protected virtual List<UnstableEvent> Events { get; } = new List<UnstableEvent>();
        protected virtual float Timer { get; set; }
        public float duration = 5f;
        protected void Start()
        {
            Timer = duration;
            Events.Add(new RotatePlatformUnstableEvent() { platform = platform });
            Events.Add(new UnstableEvent());
            Events.Add(new ReversedControllsUnstableEvent() { controllableModels = new GameObject[] {controllableModel } });
            Events.Add(new ChangeGravityUnstableEvent() { controllableModels = new GameObject[] {controllableModel } });
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
            if (Timer > 0)
            {
                if (CurrentEvent is UpdatableUnstableEvent uue)
                {
                    uue?.UpdateEventEffect();
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
                }
            }
        }
    }
}
