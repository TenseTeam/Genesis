namespace ProjectGenesis.Environment.Portals
{
    using UnityEngine;
    using VUDK.Extensions.Transform;
    using VUDK.Generic.Systems.EntitySystem.Interfaces;
    using VUDK.Generic.Systems.InputSystem;
    using VUDK.Patterns.StateMachine;
    using ProjectGenesis.Settings;
    using ProjectGenesis.Player;

    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerGraphicsController))]
    [RequireComponent(typeof(PlayerStatus))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]

    public class LinkedPlayerController : StateMachine, Player.Interfaces.IPlayer, IEntity
    {
        [SerializeField]
        private PlayerController _originalPlayer;

        private Rigidbody _rigibody;
        private Animator _anim;

        private PlayerMovement _movement;
        private PlayerGraphicsController _graphics;
        private PlayerStatus _status;

        protected void Awake()
        {
            TryGetComponent(out _movement);
            TryGetComponent(out _graphics);
            TryGetComponent(out _status);
            TryGetComponent(out _rigibody);
            TryGetComponent(out _anim);

            _movement.Init(_rigibody, GameSettings.GroundLayers);
            _graphics.Init(_anim);
            Init(_originalPlayer);
        }

        public void Init(PlayerController realPlayer)
        {
            _status = realPlayer.Status;
            Init();
        }

        public override void Init()
        {
            States = _originalPlayer.States;
        }

        public void Enable()
        {
            InputsManager.Inputs.Disable();
            InputsManager.Inputs.Enable();
            gameObject.SetActive(true);
            SetAsRealPlayer();
        }

        public void HealHitPoints(float healPoints)
        {
            _originalPlayer.Entity.HealHitPoints(healPoints);
        }

        public void TakeDamage(float hitDamage = 1)
        {
            gameObject.SetActive(false);
            _originalPlayer.Entity.TakeDamage(hitDamage);
        }

        public void Death()
        {
            _originalPlayer.Entity.Death();
        }

        private void SetAsRealPlayer()
        {
            transform.SetLossyScale(_originalPlayer.transform.lossyScale);
        }
    }
}