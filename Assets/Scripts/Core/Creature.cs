namespace ChaoticDonutFallRampage.Core
{
    /// <item>
    ///         <term><see cref="Item"/>? HoldingItem</term>
    ///     </item>
    public abstract class Creature
    {
        public event System.Action OnDeath;
        public event System.Action OnRevived;
        protected virtual CreatureConfig Config {  get; set; }
        protected int hp;
        protected virtual int MaxHp => Config?.MaxHp ?? 0;
        public virtual bool IsAlive => Hp > 0;
        public virtual void Revive()
        {
            Hp = MaxHp;
            OnRevived?.Invoke();
        }
        public virtual int Hp
        {
            get => hp;
            set
            {
                hp = value > MaxHp ? MaxHp : value < 0 ? 0 : value;
            }
        }
        protected virtual void Die()
        {
            OnDeath?.Invoke();
        }
        protected Item? holdingItem;
        public virtual Item? HoldingItem
        {
            get => holdingItem;
            set
            {
                holdingItem = value;
                holdingItem?.PickedUpBy(this);
            }
        }
        public virtual void Hit(Creature enemy)
        {
            HoldingItem?.Hit(enemy);
        }
        public virtual void RcvDmg(int value) => Hp -= value;
        public virtual void Heal(int value) => Hp += value;
        public virtual void PickItem(Item item) => HoldingItem = item;
        public Creature()
        {
            Hp = MaxHp;
        }
        public Creature(CreatureConfig config)
            :this()
        {
            Config = config;
        }
    }
}
