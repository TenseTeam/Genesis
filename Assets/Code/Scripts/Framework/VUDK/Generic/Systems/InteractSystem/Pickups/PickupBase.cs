namespace VUDK.Generic.Systems.InteractSystem.Pickups
{
    using UnityEngine;
    using VUDK.Generic.Systems.EventsSystem;
    using VUDK.Generic.Systems.EventsSystem.Events;

    public abstract class PickupBase : TriggerInteractBase
    {
        public override void Interact(GameObject interactor)
        {
            EventManager.TriggerEvent(EventKeys.InteractEvents.OnPickup);
        }
    }
}
