namespace ProjectGenesis.Environment.Portals
{
    using UnityEngine;
    using VUDK.Generic.Systems.EventsSystem;
    using ProjectGenesis.Constants.Events;
    using VUDK.Generic.Systems.TriggerSystem;

    public abstract class PortalBase : TriggerEvent
    {
        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            EventManager.TriggerEvent(EventKeys.OnEnterPortal, transform.position);
        }
    }
}