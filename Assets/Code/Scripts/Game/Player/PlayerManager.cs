namespace ProjectGenesis.Player
{
    using UnityEngine;
    using VUDK.Generic.Systems.MovementSystem;

    [RequireComponent(typeof(MovementBase))]
    [RequireComponent(typeof(PlayerGraphicsController))]
    [RequireComponent(typeof(PlayerEntity))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]
    public class PlayerManager : MonoBehaviour
    {
        public MovementBase Movement { get; private set; }
        public PlayerGraphicsController Graphics { get; private set; }
        public PlayerEntity Entity { get; private set; }

        private Rigidbody _rb;
        private Animator _anim;

        private void Awake()
        {
            TryGetComponent(out MovementBase movement);
            TryGetComponent(out PlayerGraphicsController graphics);
            TryGetComponent(out PlayerEntity entity);
            TryGetComponent(out _rb);
            TryGetComponent(out _anim);

            Movement = movement;
            Graphics = graphics;
            Entity = entity;

            Entity.Init();
            Movement.Init(_rb);
            Graphics.Init(_anim);
        }
    }
}