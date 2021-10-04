using UnityEngine;
namespace ChaoticDonutFallRampage.Core
{
    public class PlayerControllableAvatar :  MonoBehaviour
    {
        public StarterAssets.ChangableThirdPersonController thirdPersonController;
        public PlayerAvatar playerAvatar;
        protected void Start()
        {
            thirdPersonController = GetComponent<StarterAssets.ChangableThirdPersonController>();
            playerAvatar = new PlayerAvatar(new PlayerConfig());
            playerAvatar.AvatarCreature.OnDeath += SwitchControllerActiveState;
            playerAvatar.AvatarCreature.OnRevived += SwitchControllerActiveState;
            thirdPersonController.OnHit += Hit;
        }
        protected virtual void Hit(Creature cr)
        {
            playerAvatar.Hit(cr);
        }
        protected virtual void SwitchControllerActiveState()
        {
            thirdPersonController.activeState = !thirdPersonController.activeState;
        }
        protected void Update()
        {
            if (transform.position.y < -10)
            {
                playerAvatar.AvatarCreature.RcvDmg(999999);
            }
        }
    }
}
