namespace VUDK.Extensions.Audio
{
    using UnityEngine;
    using VUDK.Generic.Serializable.Audio;

    public static class AudioExtension
    {
        /// <summary>
        /// Allows the passing of AudioSFX Object into the mixer so that copies the properties.
        /// </summary>
        /// <param name="audioSetting">AudioSFX settings.</param>
        /// <param name="pos">Position you want to spawn the audio.</param>
        public static Object PlayClipAtPoint(this AudioSFX audioSetting, Vector3 pos, bool destroyAtClipEnd)
        {
            GameObject tempGO = new GameObject("ClipAtPoint " + pos);
            tempGO.transform.position = pos;
            AudioSource tempASource = tempGO.AddComponent<AudioSource>();
            tempASource.clip = audioSetting.Clip;
            tempASource.volume = audioSetting.Volume;
            tempASource.pitch = audioSetting.Pitch;
            tempASource.outputAudioMixerGroup = audioSetting.MixerGroup;
            tempASource.spatialBlend = audioSetting.SpatialBlend;
            tempASource.Play();
            if (destroyAtClipEnd)
                Object.Destroy(tempGO, tempASource.clip.length);
            return tempGO;
        }
    }
}
