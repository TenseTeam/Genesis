namespace ProjectGenesis.Environment.Traps
{
    using UnityEngine;
    using VUDK.Generic.Systems.EntitySystem.Interfaces;
    using VUDK.Generic.Systems.TriggerSystem;

    public class Trap : TriggerEvent
    {
        protected override void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out IEntity ent))
                OnEnterEntityTrap(other, ent);
        }

        protected override void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IEntity ent))
                OnExitEntityTrap(other, ent);
        }

        protected virtual void OnEnterEntityTrap(Collider other, IEntity entity)
        {
            entity.TakeDamage();
        }

        protected virtual void OnExitEntityTrap(Collider other, IEntity entity)
        {
        }
    }
}