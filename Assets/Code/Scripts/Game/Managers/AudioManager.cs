namespace ProjectGenesis.Managers
{
    using UnityEngine;
    using VUDK.Generic.Systems.EventsSystem;
    using ProjectGenesis.Constants.Events;

    public class AudioManager : VUDK.Generic.Managers.AudioManager
    {
        [SerializeField, Header("UI Clips")]
        private AudioClip _buttonClick;

        [SerializeField, Header("Game Clips")]
        private AudioClip _enterPortal;

        protected override void OnEnable()
        {
            EventManager.AddListener(EventKeys.OnUIButtonClick, () => PlayUncuncurrentEffectAudio(_buttonClick));
            EventManager.AddListener<Vector3>(EventKeys.OnEnterPortal, (position) => PlaySpatialAudio(_enterPortal, position));
        }

        protected override void OnDisable()
        {
            EventManager.RemoveListener(EventKeys.OnUIButtonClick, () => PlayUncuncurrentEffectAudio(_buttonClick));
            EventManager.RemoveListener<Vector3>(EventKeys.OnEnterPortal, (position) => PlaySpatialAudio(_enterPortal, position));
        }
    }
}