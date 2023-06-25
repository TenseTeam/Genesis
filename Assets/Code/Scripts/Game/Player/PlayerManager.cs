namespace ProjectGenesis.Player
{
    using UnityEngine;
    using VUDK.Generic.Systems.MovementSystem;

    [RequireComponent(typeof(MovementBase))]
    [RequireComponent(typeof(PlayerGraphicsController))]
    [RequireComponent(typeof(PlayerEntity))]
    [RequireComponent(typeof(PlayerStatus))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]
    public class PlayerManager : MonoBehaviour
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
            TryGetComponent(out PlayerEntity entity);
            TryGetComponent(out PlayerStatus status);
            TryGetComponent(out _rb);
            TryGetComponent(out _anim);

            Movement = movement;
            Graphics = graphics;
            Entity = entity;
            Status = status;

            Entity.Init();
            Movement.Init(_rb);
            Graphics.Init(Movement, _anim);
        }
    }
}