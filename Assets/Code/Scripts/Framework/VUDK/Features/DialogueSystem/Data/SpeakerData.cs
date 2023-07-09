namespace VUDK.Features.DialogueSystem.Data
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Dialogue/Speaker")]
    public class SpeakerData : ScriptableObject
    {
        public string SpeakerName;
        public Sprite SpeakerImage;
    }
}