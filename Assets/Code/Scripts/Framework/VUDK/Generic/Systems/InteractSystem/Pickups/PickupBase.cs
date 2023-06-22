namespace VUDK.Generic.Systems.InteractSystem.Pickups
{
    using UnityEngine;
    using VUDK.Generic.Systems.EventsSystem;
    using VUDK.Generic.Systems.EventsSystem.Events;

    public abstract class PickupBase : InteractBase, IPickup
    {
        private void OnTriggerEnter(Collider other)
        {
            EventManager.TriggerEvent(EventKeys.InteractEvents.OnPickup);
            Interact(other.gameObject);
        }

        public override void Interact(GameObject Interactor)
        {
        }
    }
}
