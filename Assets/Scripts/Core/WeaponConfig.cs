namespace ChaoticDonutFallRampage.Core
{
    public abstract class WeaponConfig : ItemConfig
    {
        protected int dmg;
        public virtual int Dmg { get => dmg; set => dmg = value > 0 ? value : 0; }
    }
}
