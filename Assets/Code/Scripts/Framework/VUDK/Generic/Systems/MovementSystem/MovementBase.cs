namespace VUDK.Generic.Systems.MovementSystem
{
    using UnityEngine;
    using VUDK.Generic.Systems.MovementSystem.Interfaces;
    using VUDK.Generic.Utility;

    public abstract class MovementBase : MonoBehaviour, IMovement
    {
        protected Rigidbody Rigidbody;
        protected float Speed;

        [SerializeField, Min(0f), Header("Ground")]
        private float _groundedRadius;
        [SerializeField]
        private Vector3 _groundedOffset;

        private LayerMask _groundLayers;

        public bool IsGrounded
        {
            get
            {
                return Physics.CheckSphere(transform.position + _groundedOffset, _groundedRadius, _groundLayers, QueryTriggerInteraction.Ignore);
            }
        }

        public virtual void Init(Rigidbody rigidBody, LayerMask groundLayers)
        {
            _groundLayers = groundLayers;
            //_groundTrigger.Init(_groundLayers);
            Rigidbody = rigidBody;
        }

        public abstract void Move();

        public abstract void Stop();

        public void SetSpeed(float speed)
        {
            Speed = speed;
        }

#if DEBUG
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.0f, 1.0f, 0.0f, 0.35f);
            Gizmos.DrawSphere(transform.position + _groundedOffset, _groundedRadius);
        }
#endif
    }
}