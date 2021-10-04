using UnityEngine;
using System.Linq;
namespace ChaoticDonutFallRampage.Core.Events
{
    public class ReversedControllsUnstableEvent : StartEndUnstableEvent
    {
        public GameObject[] controllableModels;
        public override void End()
        {
            controllableModels.ToList().ForEach(controllableModel =>
            {
                var controller = controllableModel.GetComponent<StarterAssets.ChangableThirdPersonController>();
                controller.NormalControls = true;
            });
        }
        public override void Start()
        {
            controllableModels.ToList().ForEach(controllableModel =>
            {
                var controller = controllableModel.GetComponent<StarterAssets.ChangableThirdPersonController>();
                controller.NormalControls = false;
            });
        }

    }
}
