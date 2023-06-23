namespace ProjectGenesis.Player
{
    using VUDK.Generic.Systems.EntitySystem;
    using VUDK.Generic.Systems.EventsSystem;
    using ProjectGenesis.Events;

    public class PlayerEntity : EntityBase
    {
        private void OnEnable()
        {
            OnTakeDamage += () => EventManager.TriggerEvent(Events.PlayerEvents.OnPlayerTakeDamage);
        }

        private void OnDisable()
        {
            OnTakeDamage -= () => EventManager.TriggerEvent(Events.PlayerEvents.OnPlayerTakeDamage);
        }
    }
}
