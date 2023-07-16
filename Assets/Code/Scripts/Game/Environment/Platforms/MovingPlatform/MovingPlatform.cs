namespace ProjectGenesis.Environment.Platforms
{
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.Events;
    using VUDK.Generic.Structures;

    public class MovingPlatform : Platform
    {
        [SerializeField]
        private UnityEvent _onArriveAtEndPosition;

        [SerializeField, Header("Platform Anchor")]
        private PlatformAnchor _anchor;

        [SerializeField, Header("Waypoints Path")]
        private LoopList<Vector3> _positions;

        [SerializeField, Header("Velocity")]
        private float _speed;

        [SerializeField, Header("Settings")]
        private bool _startOnAwake;
        [SerializeField]
        private bool _isLooped;

        private bool _canMove;
        private Vector3 _previousPosition;

        private void Awake()
        {
            if (_startOnAwake)
                _canMove = true;
        }

        private void Start()
        {
            _previousPosition = transform.position;
        }

        private void FixedUpdate()
        {
            if (_canMove)
                Move();
        }

        [ContextMenu("StartMove")]
        public void StartMove()
        {
            _canMove = true;
        }

        [ContextMenu("StopMove")]
        public void StopMove()
        {
            _canMove = false;
        }

        public void Move()
        {
            Vector3 targetPosition = _positions.Current;
            Vector3 direction = (targetPosition - _previousPosition).normalized;

            float distanceToMove = _speed * Time.deltaTime;
            transform.position = _previousPosition + direction * distanceToMove;
            _previousPosition = transform.position;

            float distanceToTarget = Vector3.Distance(targetPosition, transform.position);

            if (distanceToTarget <= distanceToMove)
            {
                if (_positions.IsAt(_positions.List.Count - 1) && !_isLooped)
                {
                    ArriveAtEndPosition();
                    return;
                }

                _positions.Next();
            }
        }

        protected override void OnEntityEnterPlatform(Collision entityCollision)
        {
            base.OnEntityEnterPlatform(entityCollision);
            entityCollision.transform.parent = _anchor.transform;
        }

        protected override void OnEntityExitPlatform(Collision entityCollision)
        {
            base.OnEntityExitPlatform(entityCollision);
            entityCollision.transform.parent = null;
        }

        private void ArriveAtEndPosition()
        {
            StopMove();
            _positions.List.Reverse();
            _onArriveAtEndPosition?.Invoke();
        }

#if DEBUG
        private void OnDrawGizmos()
        {
            if (_positions == null || _positions.List.Count <= 0)
                return;
            List<Vector3> pos = _positions.List.ToList();

            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, pos[0]);

            Gizmos.color = Color.green;
            for (int i = 1; i < pos.Count; i++)
            {
                Gizmos.DrawLine(pos[i - 1], pos[i]);
                Gizmos.DrawSphere(pos[i-1], transform.localScale.y / 2f);
            }

            Gizmos.DrawLine(pos[pos.Count - 1], pos[0]);
            Gizmos.DrawSphere(pos[pos.Count - 1], transform.localScale.y / 2f);
        }
#endif
    }
}
