namespace VUDK.Features.DialogueSystem
{
	using System.Collections;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;
    using VUDK.Generic.Systems.EventsSystem;
    using VUDK.Generic.Systems.EventsSystem.Events;

    public class DialogueManager : MonoBehaviour
	{
		[SerializeField, Header("Sentence")]
		private float _displayLetterTime = 0.5f;

		[SerializeField, Header("Dialogue")]
		private RectTransform _dialoguePanel;
        [SerializeField]
        private Image _speakerImage;
        [SerializeField]
        private TMP_Text _speakerName;
		[SerializeField]
		private TMP_Text _sentenceText;

        private Dialogue _dialogue;
        private Sentence _currentSentence;

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
            {
                SetSentenceSpeaker(_dialogue.Next);
                StartCoroutine(TypeSentenceRoutine(_dialogue.Current));
            }
            else
            {
                IsTalking = false;
                SetCompleteSentence(_dialogue.Current);
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

        private IEnumerator TypeSentenceRoutine(Sentence sentence)
        {
            _sentenceText.text = "";
            IsTalking = true;
            foreach (char letter in sentence.SpeakerPhrase.ToCharArray())
            {
                EventManager.TriggerEvent(EventKeys.DialogueEvents.OnDialougeTypedLetter);
                _sentenceText.text += letter;
                yield return new WaitForSeconds(_displayLetterTime);
            }
            IsTalking = false;
        }

        private void SetSentenceSpeaker(Sentence sentence)
        {
            _speakerImage.sprite = sentence.SpeakerImage;
            _speakerName.text = sentence.SpeakerName;
        }

        private void SetCompleteSentence(Sentence sentence)
        {
            SetSentenceSpeaker(sentence);
            _sentenceText.text = sentence.SpeakerPhrase;
        }
    }
}