namespace ChaoticDonutFallRampage.Core.Events
{
    public abstract class UpdatableUnstableEvent : UnstableEvent
    {
        public abstract void UpdateEventEffect();
    }
}
