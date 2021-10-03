using System.Collections.Generic;
namespace ChaoticDonutFallRampage.Core
{
    public abstract class ItemConfig
    {
        public List<Effect> Effects { get; set; } = new List<Effect>();
    }
}
