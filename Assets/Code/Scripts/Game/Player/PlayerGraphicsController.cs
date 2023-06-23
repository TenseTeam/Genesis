namespace ProjectGenesis.Player
{
    using UnityEngine;
    using VUDK.Generic.Systems.EventsSystem;
    using ProjectGenesis.Events;
    using ProjectGenesis.Constants;

    public class PlayerGraphicsController : MonoBehaviour
    {
        private Animator _anim;

        private float _horizontal;

        private void OnEnable()
        {
            EventManager.AddListener<float>(Events.PlayerEvents.OnMovement, StartAnimatingMovement);
            EventManager.AddListener<bool>(Events.PlayerEvents.OnFalling, AnimateFalling);
            EventManager.AddListener(Events.PlayerEvents.OnJump, AnimateJump);
        }

        private void OnDisable()
        {
            EventManager.RemoveListener<float>(Events.PlayerEvents.OnMovement, StartAnimatingMovement);
            EventManager.RemoveListener<bool>(Events.PlayerEvents.OnFalling, AnimateFalling);
            EventManager.RemoveListener(Events.PlayerEvents.OnJump, AnimateJump);
        }

        private void Update()
        {
            AnimateMovement();
        }

        public void Init(Animator animator)
        {
            _anim = animator;
        }

        private void StartAnimatingMovement(float horizontalDirection)
        {
            _horizontal = horizontalDirection;
        }

        private void AnimateMovement()
        {
            _anim.SetFloat(Constants.Animations.PlayerAnimations.Horizontal, Mathf.Abs(_horizontal), 0.1f, Time.deltaTime);
        }

        private void AnimateJump()
        {
            _anim.SetTrigger(Constants.Animations.PlayerAnimations.Jump);
        }

        private void AnimateFalling(bool isFalling)
        {
            _anim.SetBool(Constants.Animations.PlayerAnimations.Falling, isFalling);
        }
    }
}