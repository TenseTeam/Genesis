namespace ProjectGenesis.Managers
{
    using UnityEngine;
    using VUDK.Generic.Systems.EventsSystem;
    using VUDK.Extensions.Audio;
    using ProjectGenesis.Events;
    using Unity.VisualScripting;
    using System.Collections.Generic;

    public class AudioManager : MonoBehaviour
    {
        [SerializeField, Header("2D AudioSources")]
        private AudioSource _music;
        private List<AudioSource> _effects;

        [SerializeField, Header("Sounds")]
        private AudioClip _portalClip;

        private void OnEnable()
        {
            EventManager.AddListener<Vector3>(Events.Portals.OnEnterPortal, (position) => Play3DAudio(_portalClip, position));
        }

        private void OnDisable()
        {
            EventManager.RemoveListener<Vector3>(Events.Portals.OnEnterPortal, (position) => Play3DAudio(_portalClip, position));
        }

        private void Play3DAudio(AudioClip clip, Vector3 position)
        {
            AudioExtension.PlayClipAtPoint(_portalClip, position);
        }

        private void Play2DAudioEffect(AudioClip clip)
        {
            AudioSource audio;

            if (TryFindFreeAudioSource(out AudioSource foundAudio))
                audio = foundAudio;
            else
            {
                audio = transform.AddComponent<AudioSource>();
                _effects.Add(audio);
            }

            PlayAudio(audio, clip);
        }

        private bool TryFindFreeAudioSource(out AudioSource audio)
        {
            foreach(AudioSource effect in _effects)
            {
                if (!effect.isPlaying)
                {
                    audio = effect;
                    return true;
                }
            }

            audio = null;
            return false;
        }

        private void PlayAudio(AudioSource source, AudioClip clip)
        {
            source.clip = clip;
            source.Play();
        }
    }
}