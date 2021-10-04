using UnityEngine;
using System.Linq;
namespace ChaoticDonutFallRampage.Core.Events
{
    public class ItemRainUnstableEvent : StartEndUnstableEvent
    {
        public GameObject platform;
        public GameObject[] fallingObjects;
        public Transform spawnPlatformTransform;
        public float spawnHeight = 20f;
        public int objAm = 20;
        public float spawnRange = 10f;
        public float[] objsSpawnTime;
        public override void Start()
        {
        }
        public override void End() { }
    }
}
