namespace VUDK.Generic.Systems.MovementSystem
{
    using UnityEngine;
    using VUDK.Generic.Systems.MovementSystem.Interfaces;

    public abstract class MovementBase : MonoBehaviour, IMovement
    {
        protected Rigidbody Rigidbody;
        protected LayerMask GroundLayers;

        [SerializeField, Min(0f), Header("Ground")]
        protected Vector3 GroundedOffset;
        [SerializeField]
        private float _groundedRadius;

        public float Speed { get; protected set; }

        public bool IsGrounded
        {
            get
            {
                return Physics.CheckSphere(transform.position + GroundedOffset, _groundedRadius, GroundLayers, QueryTriggerInteraction.Ignore);
            }
        }

        public virtual void Init(Rigidbody rigidBody, LayerMask groundLayers)
        {
            GroundLayers = groundLayers;
            Init(rigidBody);
        }

        public void Init(Rigidbody rigidBody)
        {
            Rigidbody = rigidBody;
        }

        public abstract void Move();

        public abstract void Stop();

        public void SetSpeed(float speed)
        {
            Speed = speed;
        }

#if DEBUG
        protected virtual void OnDrawGizmos()
        {
            DrawCheckGroundSphere();
        }

        private void DrawCheckGroundSphere()
        {
            Gizmos.color = new Color(0.0f, 1.0f, 0.0f, 0.35f);
            Gizmos.DrawSphere(transform.position + GroundedOffset, _groundedRadius);
        }
#endif
    }
}