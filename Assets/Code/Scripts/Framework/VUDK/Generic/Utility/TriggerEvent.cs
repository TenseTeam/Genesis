namespace VUDK.Generic.Utility
{
    using UnityEngine;
    using UnityEngine.Events;

    [RequireComponent(typeof(Collider))]
    public class TriggerEvent : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _onTriggerEnter;
        [SerializeField]
        private UnityEvent _onTriggerExit;

        protected virtual void OnTriggerEnter(Collider other)
        {
            _onTriggerEnter?.Invoke();
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            _onTriggerExit?.Invoke();
        }

        protected virtual void OnTriggerStay(Collider other)
        {
        }

#if DEBUG
        protected virtual void OnDrawGizmos()
        {
            DrawTrigger();
        }

        protected virtual void DrawTrigger()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, transform.lossyScale);
        }
#endif
    }
}