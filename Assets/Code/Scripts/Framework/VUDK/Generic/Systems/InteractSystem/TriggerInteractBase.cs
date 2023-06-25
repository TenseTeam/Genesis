namespace VUDK.Generic.Systems.InteractSystem
{
    using UnityEngine;

    public abstract class TriggerInteractBase : InteractBase
    {
        private void OnTriggerEnter(Collider other)
        {
            Interact(other.gameObject);
        }
    }
}
