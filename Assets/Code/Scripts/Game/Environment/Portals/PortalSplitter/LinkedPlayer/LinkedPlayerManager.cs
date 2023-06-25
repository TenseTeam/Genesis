namespace ProjectGenesis.Environment.Portals
{
    using UnityEngine;
    using VUDK.Extensions.Transform;
    using VUDK.Generic.Systems.EntitySystem.Interfaces;
    using VUDK.Generic.Systems.MovementSystem;
    using ProjectGenesis.Player;
    using ProjectGenesis.Player.Interfaces;
    using ProjectGenesis.Settings;
    using VUDK.Generic.Systems.InputSystem;

    [RequireComponent(typeof(MovementBase))]
    [RequireComponent(typeof(PlayerGraphicsController))]
    [RequireComponent(typeof(PlayerStatus))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]

    public class LinkedPlayerManager : MonoBehaviour, IEntity, IPlayerManager
    {
        public PlayerMovement Movement { get; private set; }
        public PlayerGraphicsController Graphics { get; private set; }
        public PlayerEntity Entity { get; private set; }
        public PlayerStatus Status { get; private set; }

        private Rigidbody _rb;
        private Animator _anim;

        private void Awake()
        {
            TryGetComponent(out PlayerMovement movement);
            TryGetComponent(out PlayerGraphicsController graphics);
            TryGetComponent(out PlayerStatus status);
            TryGetComponent(out _rb);
            TryGetComponent(out _anim);

            Movement = movement;
            Graphics = graphics;
            Status = status;

            Movement.Init(_rb, ProjectSettings.GroundLayers);
            Graphics.Init(Movement, _anim);
        }

        public void Init()
        {
        }

        public void Init(PlayerManager realPlayer)
        {
            Entity = realPlayer.Entity;
            InputsManager.Inputs.Disable();
            InputsManager.Inputs.Enable();
            SetAsRealPlayer(realPlayer);
            gameObject.SetActive(true);
        }

        public void HealHitPoints(float healPoints)
        {
            Entity.HealHitPoints(healPoints);
        }

        [ContextMenu("DebugTakeDamage")]
        public void TakeDamage(float hitDamage = 1)
        {
            Entity.TakeDamage(hitDamage);
        }

        public void Death()
        {
            Entity.Death();
        }

        private void SetAsRealPlayer(PlayerManager realPlayer)
        {
            transform.SetLossyScale(realPlayer.transform.lossyScale);
        }
    }
}