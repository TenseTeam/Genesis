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

        private PlayerMovement _playerMovement;

        private void OnEnable()
        {
            _playerMovement.OnMovement += StartAnimatingMovement;
            _playerMovement.OnFalling += AnimateFalling;
            _playerMovement.OnJump += AnimateJump;
        }

        private void OnDisable()
        {
            _playerMovement.OnMovement -= StartAnimatingMovement;
            _playerMovement.OnFalling -= AnimateFalling;
            _playerMovement.OnJump -= AnimateJump;
        }

        private void Update()
        {
            AnimateMovement();
        }

        public void Init(PlayerMovement movement, Animator animator)
        {
            _anim = animator;
            _playerMovement = movement;
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