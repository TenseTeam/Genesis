namespace ProjectGenesis.Environment.Platforms
{
    using UnityEngine;
    using VUDK.Extensions.Transform;

    public class PlatformAnchor : MonoBehaviour
    {
        private void Awake()
        {
            transform.SetLossyScale(Vector3.one);
        }
    }
}
