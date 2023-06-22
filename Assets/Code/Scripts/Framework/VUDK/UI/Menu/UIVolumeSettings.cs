namespace VUDK.UI.Menu
{
    using VUDK.DataSave.MenuPreferences;
    using UnityEngine;
    using UnityEngine.Audio;
    using UnityEngine.UI;

    public class UIVolumeSettings : MonoBehaviour
    {
        public AudioMixer mixer;
        public Slider masterSlider, musicSlider, effectsSlider;

        private void Awake()
        {
            if (MenuPrefsSaver.Audio.LoadVolume(out float master, out float music, out float sfx))
            {
                mixer.SetFloat("Master", master);
                mixer.SetFloat("Music", music);
                mixer.SetFloat("Effects", sfx);

                masterSlider.value = master;
                musicSlider.value = music;
                effectsSlider.value = sfx;
            }
            else
            {
                // If there were no saved values then we set the volume to 0 (that means +0dB)
                mixer.SetFloat("Master", 0);
                mixer.SetFloat("Music", 0);
                mixer.SetFloat("Effects", 0);
            }
        }

        /// <summary>
        /// Sets the master volume.
        /// </summary>
        public void SetMaster()
        {
            mixer.SetFloat("Master", masterSlider.value);
            MenuPrefsSaver.Audio.SaveVolume(masterSlider.value, musicSlider.value, effectsSlider.value);
        }

        /// <summary>
        /// Sets the music volume.
        /// </summary>
        public void SetMusic()
        {
            mixer.SetFloat("Music", musicSlider.value);
            MenuPrefsSaver.Audio.SaveVolume(masterSlider.value, musicSlider.value, effectsSlider.value);
        }

        /// <summary>
        /// Sets
        /// </summary>
        public void SetEffects()
        {
            mixer.SetFloat("Effects", effectsSlider.value);
            MenuPrefsSaver.Audio.SaveVolume(masterSlider.value, musicSlider.value, effectsSlider.value);
        }
    }
}