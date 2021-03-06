using UnityEngine;
using System.Linq;
namespace ChaoticDonutFallRampage.Core.Events
{
    public class ChangeGravityUnstableEvent : StartEndUnstableEvent
    {
        public GameObject[] controllableModels;
        public override void End()
        {
            controllableModels.ToList().ForEach(controllableModel =>
            {
                var controller = controllableModel.GetComponent<StarterAssets.ChangableThirdPersonController>();
                controller.CurGravity = controller.DefaultGravity;
            });
        }

        public override void Start()
        {
            controllableModels.ToList().ForEach(controllableModel =>
            {
                var controller = controllableModel.GetComponent<StarterAssets.ChangableThirdPersonController>();
                controller.CurGravity = controller.DefaultGravity / 10;
            });
        }
    }
}
