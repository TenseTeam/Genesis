namespace ProjectGenesis.Managers
{
    using UnityEngine;
    using VUDK.Generic.Systems.EventsSystem;
    using ProjectGenesis.Events;

    public class AudioManager : VUDK.Generic.Managers.AudioManager
    {
        [SerializeField, Header("Sounds")]
        private AudioClip _portalClip;

        protected override void OnEnable()
        {
            EventManager.AddListener<Vector3>(Events.Portals.OnEnterPortal, (position) => Play3DClip(_portalClip, position));
        }

        protected override void OnDisable()
        {
            EventManager.RemoveListener<Vector3>(Events.Portals.OnEnterPortal, (position) => Play3DClip(_portalClip, position));
        }
    }
}