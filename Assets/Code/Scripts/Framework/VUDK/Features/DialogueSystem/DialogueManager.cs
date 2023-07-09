namespace VUDK.Features.DialogueSystem
{
    using System.Collections;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;
    using VUDK.Features.DialogueSystem.Data;
    using VUDK.Generic.Systems.EventsSystem;
    using VUDK.Generic.Systems.EventsSystem.Events;

    public class DialogueManager : MonoBehaviour
    {
        [SerializeField, Min(0.01f), Header("Sentence")]
        private float _displayLetterTime;

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

        public bool IsDialogueOpen => _dialoguePanel.gameObject.activeSelf;
        public bool IsTalking { get; private set; }

        private void OnEnable()
        {
            EventManager.AddListener<Dialogue>(EventKeys.DialogueEvents.OnTriggeredDialouge, StartDialogue);
        }

        private void OnDisable()
        {
            EventManager.RemoveListener<Dialogue>(EventKeys.DialogueEvents.OnTriggeredDialouge, StartDialogue);
        }

        public void StartDialogue(Dialogue dialogue)
        {
            EventManager.TriggerEvent(EventKeys.DialogueEvents.OnStartDialogue);
            _dialogue = dialogue;
            _dialoguePanel.gameObject.SetActive(true);
            DisplayNextSentence();
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
                _currentSentence = _dialogue.NextSentence();
                SetSentenceSpeaker(_dialogue.GetSpeakerForSentence(_currentSentence));
                StartCoroutine(TypeSentenceRoutine(_currentSentence));
            }
            else
            {
                IsTalking = false;
                SetCompleteSentence(_currentSentence);
            }
        }

        private void EndDialogue()
        {
            EventManager.TriggerEvent(EventKeys.DialogueEvents.OnEndDialogue);
            _dialoguePanel.gameObject.SetActive(false);
            _sentenceText.text = "";
        }

        private IEnumerator TypeSentenceRoutine(Sentence sentence)
        {
            _sentenceText.text = "";
            IsTalking = true;
            foreach (char letter in sentence.Phrase.ToCharArray())
            {
                EventManager.TriggerEvent(EventKeys.DialogueEvents.OnDialougeTypedLetter);
                _sentenceText.text += letter;
                yield return new WaitForSeconds(_displayLetterTime);
            }
            IsTalking = false;
        }

        private void SetSentenceSpeaker(SpeakerData speaker)
        {
            _speakerImage.sprite = speaker.SpeakerImage;
            _speakerName.text = speaker.SpeakerName;
        }

        private void SetCompleteSentence(Sentence sentence)
        {
            SetSentenceSpeaker(_dialogue.GetSpeakerForSentence(sentence));
            _sentenceText.text = sentence.Phrase;
        }
    }
}