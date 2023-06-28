namespace ProjectGenesis.Environment.Platforms
{
    using UnityEngine;
    using VUDK.Generic.Systems.EntitySystem.Interfaces;

    [RequireComponent(typeof(Rigidbody))]
    public class Platform : MonoBehaviour
    {
        [SerializeField]
        private PlatformAnchor _anchor;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent(out IEntity ent))
            {
                collision.transform.parent = _anchor.transform;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.transform.TryGetComponent(out IEntity ent))
            {
                collision.transform.parent = null;
            }
        }
    }
}
