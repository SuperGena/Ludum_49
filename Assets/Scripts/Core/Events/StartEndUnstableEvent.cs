namespace ChaoticDonutFallRampage.Core.Events
{
    public abstract class StartEndUnstableEvent : UnstableEvent
    {
        public abstract void Start();
        public abstract void End();
    }
}
