namespace ProjectGenesis.Environment.Portals
{
    using UnityEngine;
    using ProjectGenesis.Player;

    public class PortalScaler : PortalBase
    {
        [SerializeField, Min(0.001f), Header("Scale")]
        private Vector3 _newSize;

        protected override void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerController player))
            {
                base.OnTriggerEnter(other);
                player.Status.ToggleResize(_newSize);
            }
        }
    }
}