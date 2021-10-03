namespace ChaoticDonutFallRampage.Core
{
    /// <summary>
    /// <para>Abstract. Used to configure specific creatures</para>
    /// <para>Implemented by, for example, <see cref="BobConfig"/></para>
    /// <para>Contains:</para>
    /// <list type="bullet">
    ///     <item>
    ///         <term>int MaxHp</term>
    ///     </item>
    ///     <item>
    ///         <term>float MaxSpeed</term>
    ///     </item>
    /// </list>
    /// </summary>
    public abstract class CreatureConfig
    {
        public float MaxSpeed { get; set; } = 5f;
        public int MaxHp { get; set; } = 100;
        public float JumpForce { get; set; } = 1f;
    }
}
