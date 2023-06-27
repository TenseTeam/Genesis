namespace ProjectGenesis.Environment.Portals
{
    using UnityEngine;
    using UnityEngine.Events;
    using VUDK.Extensions.Transform;
    using VUDK.Extensions.Gizmos;
    using VUDK.Generic.Systems.EventsSystem;
    using ProjectGenesis.Events;
    using ProjectGenesis.Player;

    public class PortalTeleport : PortalBase
    {
        public UnityEvent OnArrive;

        [SerializeField, Header("Destination")]
        private PortalTeleport _portalDestination;

        [field: SerializeField]
        public Vector3 DestinationOnArriveOffset { get; private set; }

        public bool IsTeleporting { get; private set; }

        public override void Interact(GameObject interactor)
        {
            if(interactor.TryGetComponent(out PlayerController player) && !IsTeleporting)
            {
                OnUse?.Invoke();
                _portalDestination.TeleportAtThisPortal(interactor.transform);
            }
        }

        public void TeleportAtThisPortal(Transform traveler)
        {
            OnArrive?.Invoke();
            EventManager.TriggerEvent(Events.Portals.OnEnterPortal, transform.position);
            IsTeleporting = true;
            traveler.SetPosition(transform.position + DestinationOnArriveOffset);
        }

        public bool IsLinked()
        {
            return _portalDestination;
        }

        private void OnTriggerExit(Collider other)
        {
            IsTeleporting = false;
        }

#if DEBUG
        private void OnDrawGizmos()
        {
            Vector3 _dest = transform.position + DestinationOnArriveOffset;
            float size = transform.localScale.magnitude / 8f;

            Gizmos.DrawLine(transform.position, _dest);
            Gizmos.DrawWireSphere(_dest, size);

            if (_portalDestination)
            {
                Gizmos.color = _portalDestination.IsLinked() ? Color.yellow : Color.red;
                GizmosExtension.DrawArrow(transform.position, _portalDestination.transform.position, size*4f);
            }
        }
#endif

    }
}