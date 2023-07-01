namespace ProjectGenesis.Player
{
    using UnityEngine;
    using ProjectGenesis.Constants;

    public class PlayerGraphicsController : MonoBehaviour
    {
        private Animator _anim;

        public void Init(Animator animator)
        {
            _anim = animator;
        }

        public void AnimateMovement(float direction)
        {
            _anim.SetFloat(Constants.Animations.PlayerAnimations.Horizontal, Mathf.Abs(direction), 0.1f, Time.deltaTime);
        }

        public void AnimateJump()
        {
            _anim.SetTrigger(Constants.Animations.PlayerAnimations.Jump);
        }

        public void AnimateFalling(bool isFalling)
        {
            _anim.SetBool(Constants.Animations.PlayerAnimations.Falling, isFalling);
        }
    }
}