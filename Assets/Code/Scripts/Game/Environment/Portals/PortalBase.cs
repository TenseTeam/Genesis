namespace ProjectGenesis.Environment.Portals
{
    using UnityEngine;
    using UnityEngine.Events;
    using VUDK.Generic.Systems.EventsSystem;
    using VUDK.Generic.Systems.InteractSystem;
    using ProjectGenesis.Events;

    public abstract class PortalBase : TriggerInteractBase
    {
        public UnityEvent OnUse;

        public override void Interact(GameObject interactor)
        {
            EventManager.TriggerEvent(Events.Portals.OnEnterPortal, transform.position);
            OnUse?.Invoke();
        }
    }
}