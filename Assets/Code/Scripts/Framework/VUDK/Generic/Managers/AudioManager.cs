namespace VUDK.Generic.Managers
{
    using System.Collections.Generic;
    using UnityEngine;
    using VUDK.Extensions.Audio;

    public abstract class AudioManager : MonoBehaviour
    {
        [SerializeField, Header("AudioSources")]
        private AudioSource _music;
        [SerializeField]
        private List<AudioSource> _effects;

        [SerializeField]
        private AudioSettings _settings;

        protected abstract void OnEnable();

        protected abstract void OnDisable();

        protected void Play3DClip(AudioClip clip, Vector3 position)
        {
            AudioExtension.PlayClipAtPoint(clip, position);
        }

        protected void Play2DClip(AudioClip clip)
        {
            AudioSource audio;

            if (TryFindFreeAudioSource(out AudioSource foundAudio))
                audio = foundAudio;
            else
            {
                audio = gameObject.AddComponent<AudioSource>();
                _effects.Add(audio);
            }

            PlayAudio(audio, clip);
        }

        protected void PlayAudio(AudioSource source, AudioClip clip)
        {
            source.clip = clip;
            source.Play();
        }

        private bool TryFindFreeAudioSource(out AudioSource audio)
        {
            foreach (AudioSource effect in _effects)
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
    }
}