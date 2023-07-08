namespace VUDK.Features.DialogueSystem
{
	using System.Collections;
    using TMPro;
    using UnityEngine;
    using VUDK.Generic.Systems.EventsSystem;
    using VUDK.Generic.Systems.EventsSystem.Events;

    public class DialogueManager : MonoBehaviour
	{
		[SerializeField, Header("Sentence")]
		private float _displayLetterTime = 0.5f;

		[SerializeField, Header("Text")]
		private RectTransform _dialoguePanel;
		[SerializeField]
		private TMP_Text _sentenceText;

		private Dialogue _dialogue;

		public bool IsTalking { get; private set; }

        private void OnEnable()
        {
			EventManager.AddListener<Dialogue>(EventKeys.DialogueEvents.OnTriggerDialouge, StartDialogue);
        }

        private void OnDisable()
        {
            EventManager.RemoveListener<Dialogue>(EventKeys.DialogueEvents.OnTriggerDialouge, StartDialogue);
        }

		public void DisplayNextSentence()
		{
			if (_dialogue.IsEnded && !IsTalking)
			{
				EndDialogue();
				return;
			}

			StopAllCoroutines();
			if (!IsTalking)
				StartCoroutine(TypeSentenceRoutine(_dialogue.Next()));
			else
			{
				IsTalking = false;
				_sentenceText.text = _dialogue.Current();
			}
		}

        public void StartDialogue(Dialogue dialogue)
        {
            _dialogue = dialogue;
            _dialoguePanel.gameObject.SetActive(true);
            DisplayNextSentence();
        }

        private void EndDialogue()
		{
			_dialoguePanel.gameObject.SetActive(false);
            _sentenceText.text = "";
		}

        private IEnumerator TypeSentenceRoutine(string sentence)
        {
            _sentenceText.text = "";
            IsTalking = true;
            foreach (char letter in sentence.ToCharArray())
            {
                _sentenceText.text += letter;
                yield return new WaitForSeconds(_displayLetterTime);
            }
            IsTalking = false;
        }
    }
}