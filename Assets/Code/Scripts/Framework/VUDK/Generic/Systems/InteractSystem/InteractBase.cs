namespace VUDK.Generic.Systems.InteractSystem
{
    using UnityEngine;

    public abstract class InteractBase : MonoBehaviour
    {
        /// <summary>
        /// Triggers interact.
        /// </summary>
        /// <param name="Interactor">Interactor GameObject.</param>
        public abstract void Interact(GameObject Interactor);
    }
}
