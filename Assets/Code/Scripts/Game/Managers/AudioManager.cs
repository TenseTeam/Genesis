namespace ProjectGenesis.Managers
{
    using UnityEngine;
    using VUDK.Generic.Managers;
    using VUDK.Features.DialogueSystem.Data;
    using EventKeysVUDK = VUDK.Generic.Systems.EventsSystem.Events.EventKeys;
    using EventKeys = ProjectGenesis.Constants.Events.EventKeys;

    public class AudioManager : VUDK.Generic.Managers.AudioManager
    {
        [SerializeField, Header("UI")]
        private AudioClip _buttonClick;

        [SerializeField, Header("Effects")]
        private AudioClip _enterPortal;

        [SerializeField, Header("Player Effects")]
        private AudioClip _playerJump;

        protected override void OnEnable()
        {
            GameManager.Instance.EventManager.AddListener(EventKeys.OnUIButtonClick, () => PlayUncuncurrentEffectAudio(_buttonClick));
            GameManager.Instance.EventManager.AddListener<SpeakerData>(EventKeysVUDK.DialogueEvents.OnDialougeTypedLetter, (speakerData) => PlayUncuncurrentEffectAudio(speakerData.SpeakerLetterAudio, speakerData.PitchVariation));
            GameManager.Instance.EventManager.AddListener<Vector3>(EventKeys.OnEnterPortal, (position) => PlaySpatialAudio(_enterPortal, position));

            //GameManager.Instance.EventManager.AddListener<Vector3>(EventKeys.OnPlayerStep, (position) => PlaySpatialAudio(_playerStep, position));
            GameManager.Instance.EventManager.AddListener<Vector3>(EventKeys.OnPlayerJump, (position) => PlaySpatialAudio(_playerJump, position));

            GameManager.Instance.EventManager.AddListener<AudioClip>(EventKeys.OnEnterTriggerVocal, (vocalClip) => PlayUncuncurrentEffectAudio(vocalClip));
            GameManager.Instance.EventManager.AddListener(EventKeys.OnExitTriggerVocal, StereoSourceEffect.Stop);
        }

        protected override void OnDisable()
        {
            GameManager.Instance.EventManager.RemoveListener(EventKeys.OnUIButtonClick, () => PlayUncuncurrentEffectAudio(_buttonClick));
            GameManager.Instance.EventManager.RemoveListener<SpeakerData>(EventKeysVUDK.DialogueEvents.OnDialougeTypedLetter, (speakerData) => PlayUncuncurrentEffectAudio(speakerData.SpeakerLetterAudio, speakerData.PitchVariation));
            GameManager.Instance.EventManager.RemoveListener<Vector3>(EventKeys.OnEnterPortal, (position) => PlaySpatialAudio(_enterPortal, position));

            //GameManager.Instance.EventManager.RemoveListener<Vector3>(EventKeys.OnPlayerStep, (position) => PlaySpatialAudio(_playerStep, position));
            GameManager.Instance.EventManager.RemoveListener<Vector3>(EventKeys.OnPlayerJump, (position) => PlaySpatialAudio(_playerJump, position));

            GameManager.Instance.EventManager.RemoveListener<AudioClip>(EventKeys.OnEnterTriggerVocal, (vocalClip) => PlayUncuncurrentEffectAudio(vocalClip));
            GameManager.Instance.EventManager.RemoveListener(EventKeys.OnExitTriggerVocal, StereoSourceEffect.Stop);
        }
    }
}