namespace ProjectGenesis.Environment.Portals
{
    using UnityEngine;
    using VUDK.Generic.Systems.EventsSystem;
    using ProjectGenesis.Constants.Events;
    using VUDK.Generic.Systems.TriggerSystem;
    using VUDK.Generic.Managers;

    public abstract class PortalBase : TriggerEvent
    {
        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            GameManager.Instance.EventManager.TriggerEvent(EventKeys.OnEnterPortal, transform.position);
        }
    }
}