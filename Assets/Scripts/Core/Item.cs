namespace ChaoticDonutFallRampage.Core
{
    ///<summary>
    /// <para>Abstract. Required for specific item emplementations</para>
    /// <para>For example <see cref="DamagableItem"/></para>
    /// <para>Can be held by creatures</para>
    /// </summary>
    public abstract class Item
    {
        public ItemConfig Config {  get; set; }
        public Item()
        {

        }
        public Item(ItemConfig config)
        {
            Config = config;
        }
        public virtual void Hit(Creature enemy)
        {
            foreach(var eff in Config?.Effects)
            {
                if (eff is IAppliableOnEnemy applEff)
                {
                    applEff.ApplyOnEnemy(enemy);
                }
            }
        }
        public virtual void PickedUpBy(Creature cr)
        {
            foreach(var eff in Config?.Effects)
            {
                if (eff is ISelfPassiveAppliable applEff)
                {
                    applEff.ApplySelfPassive(cr);
                }
            }
        }
    }
}
