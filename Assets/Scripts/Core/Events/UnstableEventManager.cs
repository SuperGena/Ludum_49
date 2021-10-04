using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
namespace ChaoticDonutFallRampage.Core.Events
{
    public class UnstableEventManager : MonoBehaviour
    {
        public GameObject platform;
        protected virtual UnstableEvent CurrentEvent { get; set; }
        protected virtual List<UnstableEvent> Events { get; } = new List<UnstableEvent>();
        protected virtual float Duration { get; set; }
        protected virtual float Timer { get; set; }
        protected void Start()
        {
            var duration = 5f;
            Duration = duration;
            Timer = Duration;
            Events.Add(new RotatePlatformUnstableEvent() { platform = platform });
            Events.Add(new EmptyUnstableEvent());
            CurrentEvent = GetNewUnstableEvent();
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
                CurrentEvent?.UpdateEventEffect();
            }
            else
            {
                Timer = Duration;
                CurrentEvent = GetNewUnstableEvent();
            }
        }
    }
}
