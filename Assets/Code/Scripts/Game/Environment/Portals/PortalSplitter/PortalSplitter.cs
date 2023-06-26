namespace ProjectGenesis.Environment.Portals.PortalSplitter
{
    using ProjectGenesis.Player;
    using UnityEngine;
    using VUDK.Extensions.Transform;

    public class PortalSplitter : PortalBase
    {
        [SerializeField, Header("Linked Double")]
        private LinkedPlayerManager _linkedPlayerManager;
        [SerializeField]
        private float _alignPosition;

        private Vector3 _correctSpawnPosition => Vector3.forward * _alignPosition + transform.position;

        private void Awake()
        {
            _linkedPlayerManager.gameObject.SetActive(false);
        }

        public override void Interact(GameObject interactor)
        {
            base.Interact(interactor);

            if(interactor.TryGetComponent(out PlayerManager player))
            {
                if (!player.Status.IsSplitted)
                    EnableDouble(player);
                else
                    DisableDouble(player);
            }
        }

        private void EnableDouble(PlayerManager player)
        {
            player.Status.ApplySplit();
            _linkedPlayerManager.Init(player);
            _linkedPlayerManager.Movement.ResetMovement();
            player.Movement.ResetMovement();
            _linkedPlayerManager.gameObject.SetActive(true);
            SetPlayersAtCorrectPositions(player);
        }

        private void DisableDouble(PlayerManager player)
        {
            player.Status.RemoveSplit();
            _linkedPlayerManager.gameObject.SetActive(false);
        }

        private void SetPlayersAtCorrectPositions(PlayerManager player)
        {
            player.transform.SetPosition(new Vector3(player.transform.position.x, player.transform.position.y, _correctSpawnPosition.z));
            _linkedPlayerManager.transform.SetPosition(new Vector3(_linkedPlayerManager.transform.position.x, _linkedPlayerManager.transform.position.y, _correctSpawnPosition.z));
        }

#if DEBUG
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(_correctSpawnPosition, transform.localScale.magnitude / 8f);
            Gizmos.DrawRay(_correctSpawnPosition, transform.up * transform.localScale.magnitude * 100f);
            Gizmos.DrawRay(_correctSpawnPosition, -transform.up * transform.localScale.magnitude * 100f);
        }
#endif
    }
}