namespace ProjectGenesis.Managers
{
    using UnityEngine;
    using VUDK.Generic.Systems.EventsSystem;
    using VUDK.Extensions.Audio;
    using ProjectGenesis.Events;

    public class AudioManager : MonoBehaviour
    {
        [SerializeField, Header("Sounds")]
        private AudioClip _portalClip;

        private void OnEnable()
        {
            EventManager.AddListener<Vector3>(Events.Portals.OnEnterPortal, (position) => AudioExtension.PlayClipAtPoint(_portalClip, position));
        }

        private void OnDisable()
        {
            EventManager.RemoveListener<Vector3>(Events.Portals.OnEnterPortal, (position) => AudioExtension.PlayClipAtPoint(_portalClip, position));
        }
    }
}