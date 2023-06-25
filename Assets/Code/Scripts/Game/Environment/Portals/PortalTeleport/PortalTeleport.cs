namespace ProjectGenesis.Environment.Portals
{
    using UnityEngine;
    using UnityEngine.Events;
    using VUDK.Extensions.Transform;
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
            if(interactor.TryGetComponent(out PlayerManager player) && !IsTeleporting)
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

        private void OnTriggerExit(Collider other)
        {
            IsTeleporting = false;
        }

#if DEBUG
        private void OnDrawGizmos()
        {
            Vector3 _dest = transform.position + DestinationOnArriveOffset;
            Gizmos.DrawLine(transform.position, _dest);
            Gizmos.DrawWireSphere(_dest, transform.localScale.magnitude / 8f);
        }
#endif
    }
}