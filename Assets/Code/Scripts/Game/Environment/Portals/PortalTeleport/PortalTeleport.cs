namespace ProjectGenesis.Environment.Portals
{
    using UnityEngine;
    using VUDK.Extensions.Transform;
    using VUDK.Extensions.Gizmos;
    using VUDK.Generic.Managers;
    using ProjectGenesis.Player;
    using ProjectGenesis.Constants.Events;

    public class PortalTeleport : PortalBase
    {
        [SerializeField, Header("Destination")]
        private PortalTeleport _portalDestination;

        [field: SerializeField]
        public Vector3 DestinationOnArriveOffset { get; private set; }

        public bool IsTeleporting { get; private set; }

        protected override void OnTriggerEnter(Collider interactor)
        {
            if(interactor.TryGetComponent(out PlayerController player) && !IsTeleporting)
            {
                OnEnter?.Invoke();
                GameManager.Instance.EventManager.TriggerEvent(EventKeys.OnEnterTeleport);
                _portalDestination.TeleportAtThisPortal(interactor.transform);
            }
        }

        public void TeleportAtThisPortal(Transform traveler)
        {
            OnExit?.Invoke();
            GameManager.Instance.EventManager.TriggerEvent(EventKeys.OnEnterPortal, transform.position);
            IsTeleporting = true;
            traveler.SetPosition(transform.position + DestinationOnArriveOffset);
        }

        public bool IsLinked()
        {
            return _portalDestination;
        }

        protected override void OnTriggerExit(Collider other)
        {
            IsTeleporting = false;
        }

#if DEBUG
        protected override void OnDrawGizmos()
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