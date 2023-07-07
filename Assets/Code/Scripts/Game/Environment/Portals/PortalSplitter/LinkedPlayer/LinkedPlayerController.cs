namespace ProjectGenesis.Environment.Portals
{
    using UnityEngine;
    using VUDK.Extensions.Transform;
    using VUDK.Generic.Systems.EntitySystem.Interfaces;
    using VUDK.Generic.Systems.InputSystem;
    using ProjectGenesis.Settings;
    using ProjectGenesis.Player;
    using ProjectGenesis.Player.Interfaces;
    using Unity.VisualScripting;

    public class LinkedPlayerController : PlayerController, IEntity, Player.Interfaces.IPlayer
    {
        [SerializeField]
        private PlayerController _originalPlayer;

        protected override void Awake()
        {
            TryGetComponent(out PlayerMovement movement);
            TryGetComponent(out PlayerGraphicsController graphics);
            TryGetComponent(out PlayerStatus status);
            TryGetComponent(out Rigidbody);
            TryGetComponent(out Animator);

            Movement = movement;
            Graphics = graphics;
            Status = status;

            Movement.Init(Rigidbody, GameSettings.GroundLayers);
            Graphics.Init(Animator);
            Init(_originalPlayer);
        }

        public void Init(PlayerController realPlayer)
        {
            Status = realPlayer.Status;
            Entity = realPlayer.Entity;
            Init();
        }

        public void Enable()
        {
            InputsManager.Inputs.Disable();
            InputsManager.Inputs.Enable();
            SetAsRealPlayer();
            gameObject.SetActive(true);
        }

        public void HealHitPoints(float healPoints)
        {
            Entity.HealHitPoints(healPoints);
        }

        public void TakeDamage(float hitDamage = 1)
        {
            gameObject.SetActive(false);
            Entity.TakeDamage(hitDamage);
        }

        public void Death()
        {
            Entity.Death();
        }

        private void SetAsRealPlayer()
        {
            transform.SetLossyScale(_originalPlayer.transform.lossyScale);
        }
    }
}