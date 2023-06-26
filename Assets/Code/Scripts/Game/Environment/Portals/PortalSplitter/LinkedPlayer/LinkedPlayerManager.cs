namespace ProjectGenesis.Environment.Portals
{
    using UnityEngine;
    using VUDK.Extensions.Transform;
    using VUDK.Generic.Systems.EntitySystem.Interfaces;
    using VUDK.Generic.Systems.MovementSystem;
    using VUDK.Generic.Systems.InputSystem;
    using ProjectGenesis.Player;
    using ProjectGenesis.Player.Interfaces;
    using ProjectGenesis.Settings;

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
            TryGetComponent(out _rb);
            TryGetComponent(out _anim);

            Movement = movement;
            Graphics = graphics;

            Movement.Init(_rb, ProjectSettings.GroundLayers);
            Graphics.Init(Movement, _anim);
        }

        public void Init()
        {
        }

        public void Init(PlayerManager realPlayer)
        {
            Status = realPlayer.Status;
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

        public void TakeDamage(float hitDamage = 1)
        {
            gameObject.SetActive(false);
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