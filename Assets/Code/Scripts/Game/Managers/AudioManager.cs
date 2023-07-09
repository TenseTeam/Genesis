namespace ProjectGenesis.Managers
{
    using UnityEngine;
    using VUDK.Generic.Systems.EventsSystem;
    using EventKeysVUDK = VUDK.Generic.Systems.EventsSystem.Events.EventKeys;
    using EventKeys = ProjectGenesis.Constants.Events.EventKeys;
    using VUDK.Generic.Serializable.Mathematics;
    using VUDK.Features.DialogueSystem.Data;

    public class AudioManager : VUDK.Generic.Managers.AudioManager
    {
        [SerializeField, Header("UI")]
        private AudioClip _buttonClick;

        [SerializeField, Header("Effects")]
        private AudioClip _enterPortal;

        protected override void OnEnable()
        {
            EventManager.AddListener(EventKeys.OnUIButtonClick, () => PlayUncuncurrentEffectAudio(_buttonClick));
            EventManager.AddListener<SpeakerData>(EventKeysVUDK.DialogueEvents.OnDialougeTypedLetter, (speakerData) => PlayUncuncurrentEffectAudio(speakerData.SpeakerLetterAudio, speakerData.PitchVariation));
            EventManager.AddListener<Vector3>(EventKeys.OnEnterPortal, (position) => PlaySpatialAudio(_enterPortal, position));
        }

        protected override void OnDisable()
        {
            EventManager.RemoveListener(EventKeys.OnUIButtonClick, () => PlayUncuncurrentEffectAudio(_buttonClick));
            EventManager.RemoveListener<SpeakerData>(EventKeysVUDK.DialogueEvents.OnDialougeTypedLetter, (speakerData) => PlayUncuncurrentEffectAudio(speakerData.SpeakerLetterAudio, speakerData.PitchVariation));
            EventManager.RemoveListener<Vector3>(EventKeys.OnEnterPortal, (position) => PlaySpatialAudio(_enterPortal, position));
        }
    }
}