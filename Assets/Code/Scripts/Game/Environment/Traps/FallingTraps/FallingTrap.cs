namespace ProjectGenesis.Environment.Traps
{
    using System.Collections;
    using UnityEngine;
    using VUDK.Patterns.ObjectPool;
    using VUDK.Patterns.ObjectPool.Interfaces;

    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class FallingTrap : Trap, IPooledObject
    {
        private float _disposeTime;
        private Rigidbody _rigidbody;

        public Pool RelatedPool { get; private set; }

        private void Awake()
        {
            TryGetComponent(out _rigidbody);
        }

        private void OnEnable()
        {
            CancelInvoke();
            Invoke("Dispose", _disposeTime);
        }

        public void Init(float disposeTime)
        {
            _disposeTime = disposeTime;
        }

        public void AssociatePool(Pool associatedPool)
        {
            RelatedPool = associatedPool;
        }

        public void Clear()
        {
            _rigidbody.velocity = Vector3.zero;
        }

        public void Dispose()
        {
            RelatedPool.Dispose(gameObject);
        }
    }
}