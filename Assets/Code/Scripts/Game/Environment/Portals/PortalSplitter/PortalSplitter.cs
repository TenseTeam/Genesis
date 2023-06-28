namespace ProjectGenesis.Environment.Portals.PortalSplitter
{
    using ProjectGenesis.Player;
    using UnityEngine;
    using VUDK.Extensions.Transform;

    public class PortalSplitter : PortalBase
    {
        [SerializeField, Header("Linked Double")]
        private LinkedPlayerController _linkedPlayerManager;
        [SerializeField]
        private Vector3 _playerAlignPosition;
        [SerializeField]
        private Vector3 _linkedPlayerAlignPosition;

        private void Awake()
        {
            _linkedPlayerManager.gameObject.SetActive(false);
        }

        public override void Interact(GameObject interactor)
        {
            base.Interact(interactor);

            if (interactor.TryGetComponent(out PlayerController player))
            {
                if (!player.Status.IsSplitted)
                    EnableDouble(player);
                else
                    DisableDouble(player);
            }
        }

        private void EnableDouble(PlayerController player)
        {
            player.Status.ApplySplit();
            _linkedPlayerManager.Enable();
            _linkedPlayerManager.gameObject.SetActive(true);
            SetPlayersAtCorrectPositions(player);
        }

        private void DisableDouble(PlayerController player)
        {
            player.Status.RemoveSplit();
            _linkedPlayerManager.gameObject.SetActive(false);
        }

        private void SetPlayersAtCorrectPositions(PlayerController player)
        {
            player.transform.SetPosition(transform.position + _playerAlignPosition);
            _linkedPlayerManager.transform.SetPosition(transform.position + _linkedPlayerAlignPosition);
        }

#if DEBUG
        private void OnDrawGizmos()
        {
            Vector3 playerPos = transform.position + _playerAlignPosition;
            Vector3 linkedPos = transform.position + _linkedPlayerAlignPosition;

            Gizmos.DrawLine(transform.position, playerPos);
            Gizmos.DrawWireSphere(playerPos, transform.localScale.magnitude / 8f);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, linkedPos);
            Gizmos.DrawWireSphere(linkedPos, transform.localScale.magnitude / 8f);
        }
#endif
    }
}