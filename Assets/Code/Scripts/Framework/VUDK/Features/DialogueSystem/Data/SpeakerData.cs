namespace VUDK.Features.DialogueSystem.Data
{
    using UnityEngine;
    using VUDK.Generic.Serializable.Mathematics;

    [CreateAssetMenu(menuName = "Dialogue/Speaker")]
    public class SpeakerData : ScriptableObject
    {
        public string SpeakerName;
        public Sprite SpeakerImage;

        [Header("Audio")]
        public AudioClip SpeakerLetterAudio;
        public Range<float> PitchVariation;
    }
}