namespace VUDK.Generic.Systems.InteractSystem.Pickups
{
    using UnityEngine;
    using VUDK.Generic.Systems.EventsSystem;
    using VUDK.Generic.Systems.EventsSystem.Events;
    using VUDK.Generic.Systems.InteractSystem.Pickups;

    public abstract class PickupBase2D : InteractBase, IPickup
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            EventManager.TriggerEvent(EventKeys.InteractEvents.OnPickup);
            Interact(other.gameObject);
        }

        public override void Interact(GameObject Interactor)
        {
        }
    }
}
