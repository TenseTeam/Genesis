namespace VUDK.Features.DialogueSystem
{
	using UnityEngine;

	public struct Sentence
	{
		public string SpeakerName;
		public Sprite SpeakerImage;
		public string SpeakerPhrase;
    }

	[System.Serializable]
	public class Dialogue
	{
		[TextArea(3, 10), SerializeField, Header("Sentences")]
		private Sentence[] _sentences;

		private int _index = 0;

        public bool IsEnded => _index == _sentences.Length - 1;

        public Sentence Next => _sentences[_index++];

		public Sentence Previous => _sentences[_index--];

		public Sentence Current => _sentences[_index];
	}
}