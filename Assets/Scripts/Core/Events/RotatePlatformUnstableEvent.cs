using UnityEngine;
namespace ChaoticDonutFallRampage.Core.Events
{
    public class RotatePlatformUnstableEvent : UpdatableUnstableEvent
    {
        public GameObject platform;
        public float rotationSpeed = 15f;
        public override void UpdateEventEffect()
        {
            platform.transform.Rotate(Vector2.up, rotationSpeed * Time.deltaTime);
        }
    }
}
