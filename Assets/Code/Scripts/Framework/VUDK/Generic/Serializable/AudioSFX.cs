namespace VUDK.Generic.Serializable.Audio
{
    using UnityEngine;
    using UnityEngine.Audio;

    [System.Serializable]
    public class AudioSFX
    {
        [Header("Audio")]
        public AudioClip Clip;
        public AudioMixerGroup MixerGroup;

        [Range(0, 1), Header("Volume")]
        public float Volume = 1;
        [Range(-3, 3)]
        public float Pitch = 1;
        [Range(0, 1)]
        public float SpatialBlend;

        /// <summary>
        /// Initializes an AudioSFX object.
        /// </summary>
        /// <param name="clip">AudioClip.</param>
        /// <param name="volume">Volume.</param>
        /// <param name="pitch">Pitch.</param>
        /// <param name="spatialBlend">SpatialBlend 2D ~ 3D.</param>
        /// <param name="mixerGroup">AudioMixerGroup.</param>
        public AudioSFX(AudioClip clip, float volume, float pitch, float spatialBlend, AudioMixerGroup mixerGroup)
        {
            Clip = clip;
            Volume = volume;
            Pitch = pitch;
            SpatialBlend = spatialBlend;
            MixerGroup = mixerGroup;
        }
    }
}
