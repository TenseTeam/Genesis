namespace ProjectGenesis.Player
{
    using UnityEngine;
    using VUDK.Generic.Systems.MovementSystem;
    using ProjectGenesis.Player.Interfaces;
    using ProjectGenesis.Settings;

    [RequireComponent(typeof(MovementBase))]
    [RequireComponent(typeof(PlayerGraphicsController))]
    [RequireComponent(typeof(PlayerEntity))]
    [RequireComponent(typeof(PlayerStatus))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]
    public class PlayerManager : MonoBehaviour, IPlayerManager
    {
        private Rigidbody _rb;
        private Animator _anim;

        public PlayerMovement Movement { get; private set; }
        public PlayerGraphicsController Graphics { get; private set; }
        public PlayerEntity Entity { get; private set; }
        public PlayerStatus Status { get; private set; }

        private void Awake()
        {
            TryGetComponent(out PlayerMovement movement);
            TryGetComponent(out PlayerGraphicsController graphics);
            TryGetComponent(out PlayerEntity entity);
            TryGetComponent(out PlayerStatus status);
            TryGetComponent(out _rb);
            TryGetComponent(out _anim);

            Movement = movement;
            Graphics = graphics;
            Entity = entity;
            Status = status;

            Entity.Init(this, transform.position);
            Movement.Init(_rb, ProjectSettings.GroundLayers);
            Graphics.Init(Movement, _anim);
        }

        public void Reset()
        {
            Status.Clear();
        }
    }
}