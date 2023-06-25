namespace VUDK.Generic.Systems.MovementSystem
{
    using UnityEngine;
    using VUDK.Generic.Systems.MovementSystem.Interfaces;
    using VUDK.Generic.Utility;

    public abstract class MovementBase : MonoBehaviour, IMovement
    {
        protected Rigidbody Rigidbody;

        [SerializeField, Header("Movement Speeds")]
        protected float GroundSpeed;
        [SerializeField]
        protected float AirSpeed;

        [SerializeField, Header("Boundaries")]
        private TriggerLink _groundTrigger;
        [SerializeField]
        private TriggerLink _wallTrigger;

        private LayerMask _groundLayers;

        public bool IsGrounded
        {
            get
            {
                return _groundTrigger.IsTriggered;
            }
        }

        public bool IsWalled
        {
            get
            {
                return !IsGrounded && _wallTrigger.IsTriggered;
            }
        }

        public virtual void Init(Rigidbody rigidBody, LayerMask groundLayers)
        {
            _groundLayers = groundLayers;
            _groundTrigger.Init(_groundLayers);
            _wallTrigger.Init(_groundLayers);
            Rigidbody = rigidBody;
        }

        public abstract void Move();

        public abstract void ResetMovement();

        public abstract void Stop();
    }
}