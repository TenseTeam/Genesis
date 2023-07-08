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
		private TMP_Text _dialogueText;
		[SerializeField]
		private RectTransform _dialoguePanel;

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
				_dialogueText.text = _dialogue.Current();
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
            _dialogueText.text = "";
		}

        private IEnumerator TypeSentenceRoutine(string sentence)
        {
            _dialogueText.text = "";
            IsTalking = true;
            foreach (char letter in sentence.ToCharArray())
            {
                _dialogueText.text += letter;
                yield return new WaitForSeconds(_displayLetterTime);
            }
            IsTalking = false;
        }
    }
}