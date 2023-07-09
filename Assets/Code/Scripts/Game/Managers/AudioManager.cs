﻿namespace ProjectGenesis.Managers
{
    using UnityEngine;
    using VUDK.Generic.Managers;
    using VUDK.Generic.Systems.EventsSystem;
    using VUDK.Features.DialogueSystem.Data;
    using EventKeysVUDK = VUDK.Generic.Systems.EventsSystem.Events.EventKeys;
    using EventKeys = ProjectGenesis.Constants.Events.EventKeys;

    public class AudioManager : VUDK.Generic.Managers.AudioManager
    {
        [SerializeField, Header("UI")]
        private AudioClip _buttonClick;

        [SerializeField, Header("Effects")]
        private AudioClip _enterPortal;

        protected override void OnEnable()
        {
            GameManager.Instance.EventManager.AddListener(EventKeys.OnUIButtonClick, () => PlayUncuncurrentEffectAudio(_buttonClick));
            GameManager.Instance.EventManager.AddListener<SpeakerData>(EventKeysVUDK.DialogueEvents.OnDialougeTypedLetter, (speakerData) => PlayUncuncurrentEffectAudio(speakerData.SpeakerLetterAudio, speakerData.PitchVariation));
            GameManager.Instance.EventManager.AddListener<Vector3>(EventKeys.OnEnterPortal, (position) => PlaySpatialAudio(_enterPortal, position));
        }

        protected override void OnDisable()
        {
            GameManager.Instance.EventManager.RemoveListener(EventKeys.OnUIButtonClick, () => PlayUncuncurrentEffectAudio(_buttonClick));
            GameManager.Instance.EventManager.RemoveListener<SpeakerData>(EventKeysVUDK.DialogueEvents.OnDialougeTypedLetter, (speakerData) => PlayUncuncurrentEffectAudio(speakerData.SpeakerLetterAudio, speakerData.PitchVariation));
            GameManager.Instance.EventManager.RemoveListener<Vector3>(EventKeys.OnEnterPortal, (position) => PlaySpatialAudio(_enterPortal, position));
        }
    }
}