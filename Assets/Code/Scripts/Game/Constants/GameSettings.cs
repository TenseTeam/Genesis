namespace ProjectGenesis.Settings
{
    using UnityEngine;

    public class GameSettings : MonoBehaviour
    {
        [SerializeField, Header("Layers")]
        private LayerMask _groundLayers;

        public static LayerMask GroundLayers { get; private set; }

        private void Awake()
        {
            GroundLayers = _groundLayers;
        }
    }
}
