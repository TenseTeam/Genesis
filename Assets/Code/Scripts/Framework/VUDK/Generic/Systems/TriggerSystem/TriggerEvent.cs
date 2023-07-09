namespace VUDK.Generic.Systems.TriggerSystem
{
    using UnityEngine;
    using UnityEngine.Events;
    using VUDK.Extensions.Gizmos;

    [RequireComponent(typeof(Collider))]
    public class TriggerEvent : MonoBehaviour
    {
        [SerializeField, Header("Events")]
        protected UnityEvent OnEnter;
        [SerializeField]
        protected UnityEvent OnExit;

        protected virtual void OnTriggerEnter(Collider other)
        {
            OnEnter?.Invoke();
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            OnExit?.Invoke();
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
            GizmosExtension.DrawWireCubeWithRotation(transform.position, transform.rotation, transform.lossyScale);
        }
#endif
    }
}