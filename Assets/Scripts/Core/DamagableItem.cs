namespace ChaoticDonutFallRampage.Core
{
    /// <summary>
    /// <para>Abstract. Required for specific weapon emplementations</para>
    /// <para>Extends <see cref="Item"/></para>
    /// </summary>
    abstract public class DamagableItem : Item
    {
        protected int dmg;
        public virtual int Dmg { get => dmg; set => dmg = value > 0 ? value : 0; }
        public override void Hit(Creature enemy)
        {
            enemy.RcvDmg(Dmg);
            base.Hit(enemy);
        }
    }
}
