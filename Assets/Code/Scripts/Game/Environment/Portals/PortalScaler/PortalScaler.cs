namespace ProjectGenesis.Environment.Portals
{
    using UnityEngine;
    using ProjectGenesis.Player;

    public class PortalScaler : PortalBase
    {
        [SerializeField, Min(0.001f), Header("Scale")]
        private Vector3 _newSize;

        public override void Interact(GameObject interactor)
        {
            if (interactor.TryGetComponent(out PlayerManager player))
            {
                base.Interact(interactor);
                player.Status.ToggleResize(_newSize);
            }
        }
    }
}