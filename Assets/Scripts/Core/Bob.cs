namespace ChaoticDonutFallRampage.Core
{
    /// <summary>
    /// <para>Main character, controller by players or AI</para>
    /// <para>It is created using <see cref="BobConfig"/></para>
    /// <para>It contains</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>bool IsAlive</term>
    ///     </item>
    ///     <item>
    ///         <term>bool CanBeRevived</term>
    ///     </item>
    ///     <item>
    ///         <term>int Hp</term>
    ///     </item>
    ///     <item>
    ///         <term>int RevivalsLeft</term>
    ///     </item>
    /// </list>
    /// </summary>
    public class Bob : Creature
    {
        
        public Bob()
        {
            
        }
        /// <summary>
        /// Creates a new Bob by the given config
        /// </summary>
        /// <param name="config">Important configuration required for Bob creation</param>
        public Bob(CreatureConfig config)
            :base(config)
        {
        }
        
    }
}
