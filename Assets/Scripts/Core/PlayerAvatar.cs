namespace ChaoticDonutFallRampage.Core
{
    public class PlayerAvatar
    {
        public virtual PlayerConfig Config { get; set; }
        public virtual Creature AvatarCreature { get; set; }
        protected virtual int MaxRevivals => Config?.MaxRevivals ?? 0;
        public virtual int RevivalsLeft { get; set; }
        public virtual bool CanBeRevived => MaxRevivals > 0;
        public virtual void Hit(Creature cr) => AvatarCreature.Hit(cr);
        public PlayerAvatar()
        {
            RevivalsLeft = MaxRevivals;
        }
        public PlayerAvatar(PlayerConfig config)
            : this() 
        {  
            Config = config; 
        }
    }
}
