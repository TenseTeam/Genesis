namespace ProjectGenesis.Environment.Traps
{
    using UnityEngine;
    using VUDK.Generic.Systems.EntitySystem.Interfaces;

    public class Trap : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out IEntity ent))
                ent.TakeDamage();
        }
    }
}