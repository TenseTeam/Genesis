namespace ProjectGenesis.Player
{
    using UnityEngine;
    using ProjectGenesis.Constants;
    using VUDK.Generic.Managers;
    using ProjectGenesis.Constants.Events;

    public class PlayerGraphicsController : MonoBehaviour
    {
        [SerializeField, Header("Effects")]
        private ParticleSystem _teleportEffects;
        [SerializeField]
        private ParticleSystem _sizeUpEffects;
        [SerializeField]
        private ParticleSystem _sizeDownEffects;

        private Animator _anim;

        private void OnEnable()
        {
            GameManager.Instance.EventManager.AddListener(EventKeys.OnEnterTeleport, TriggerTeleportEffect);
            GameManager.Instance.EventManager.AddListener(EventKeys.OnPlayerSizeUp, TriggerSizeUpEffect);
            GameManager.Instance.EventManager.AddListener(EventKeys.OnPlayerSizeDown, TriggerSizeDownEffect);
        }

        private void OnDisable()
        {
            GameManager.Instance.EventManager.RemoveListener(EventKeys.OnEnterTeleport, TriggerTeleportEffect);
            GameManager.Instance.EventManager.RemoveListener(EventKeys.OnPlayerSizeUp, TriggerSizeUpEffect);
            GameManager.Instance.EventManager.RemoveListener(EventKeys.OnPlayerSizeDown, TriggerSizeDownEffect);
        }

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

        public void TriggerStep()
        {
            GameManager.Instance.EventManager.TriggerEvent(EventKeys.OnPlayerStep, transform.position);
        }

        public void TriggerTeleportEffect()
        {
            _teleportEffects.Play();
        }

        public void TriggerSizeUpEffect()
        {
            _sizeDownEffects.Play();
        }

        public void TriggerSizeDownEffect()
        {
            _sizeDownEffects.Play();
        }
    }
}