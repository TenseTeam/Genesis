namespace VUDK.Generic.Utility
{
    using UnityEngine;
    using VUDK.Extensions.GameObject;

    [RequireComponent(typeof(Collider))]
    public class TriggerLink : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _triggableLayers;

        public bool IsTriggered { get; private set; }

        public void Init(LayerMask layerMask)
        {
            _triggableLayers = layerMask;
        }

        private void OnTriggerStay(Collider other)
        {
            IsTriggered = other.gameObject.IsInLayerMask(_triggableLayers);
        }

        private void OnTriggerExit(Collider other)
        {
            IsTriggered = false;
        }
    }
}