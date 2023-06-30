namespace ProjectGenesis.Environment.Traps
{
    using UnityEngine;
    using VUDK.Generic.Systems.EntitySystem;
    using VUDK.Generic.Systems.EntitySystem.Interfaces;

    [RequireComponent(typeof(Collider))]
    public class Trap : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out IEntity ent))
                OnEnterEntityTrap(other, ent);
        }

        private void OnTriggerExit(Collider other)
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