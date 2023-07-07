namespace ProjectGenesis.Environment.Platforms
{
    using UnityEngine;
    using UnityEngine.Events;
    using VUDK.Generic.Systems.EntitySystem.Interfaces;

    [RequireComponent(typeof(Rigidbody))]
    public class Platform : MonoBehaviour
    {
        [SerializeField, Header("Events")]
        private UnityEvent _onEntityOnPlatform;
        [SerializeField]
        private UnityEvent _onEntityOffPlatform;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent(out IEntity ent))
            {
                OnEntityEnterPlatform(collision);
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.transform.TryGetComponent(out IEntity ent))
            {
                OnEntityExitPlatform(collision);
            }
        }

        protected virtual void OnEntityEnterPlatform(Collision entityCollision)
        {
            _onEntityOffPlatform?.Invoke();
        }

        protected virtual void OnEntityExitPlatform(Collision entityCollision)
        {
            _onEntityOffPlatform?.Invoke();
        }
    }
}
