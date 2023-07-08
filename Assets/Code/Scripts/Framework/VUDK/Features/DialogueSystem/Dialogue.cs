﻿namespace VUDK.Features.DialogueSystem
{
	using UnityEngine;

	[System.Serializable]
	public class Dialogue
	{
		[TextArea(3, 10), SerializeField]
		private string[] _sentences;
		private int _index = 0;

        public bool IsEnded => _index == _sentences.Length - 1;

        public string Next()
		{
			return _sentences[_index++];
		}

		public string Previous()
		{
			return _sentences[_index--];
		}

		public string Current()
		{
			return _sentences[_index];
		}
	}
}