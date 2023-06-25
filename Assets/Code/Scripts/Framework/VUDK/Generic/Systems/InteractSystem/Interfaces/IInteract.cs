namespace VUDK.Generic.Systems.InteractSystem.Interfaces
{
    using UnityEngine;

    public interface IInteract
    {
        /// <summary>
        /// Interacts with this object.
        /// </summary>
        /// <param name="Interactor">Interactor GameObject.</param>
        public void Interact(GameObject interactor);
    }
}