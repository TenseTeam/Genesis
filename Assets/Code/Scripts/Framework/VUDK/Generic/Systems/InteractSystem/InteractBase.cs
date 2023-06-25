namespace VUDK.Generic.Systems.InteractSystem
{
    using UnityEngine;
    using VUDK.Generic.Systems.InteractSystem.Interfaces;

    public abstract class InteractBase : MonoBehaviour, IInteract
    {
        public abstract void Interact(GameObject interactor);
    }
}
