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

        public bool IsInUse { get; private set; }

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
            if (_dialogue.IsEnded && !IsInUse)
            {
                EndDialogue();
                return;
            }

            StopAllCoroutines();
            if (!IsInUse)
            {
                Sentence sentence = _dialogue.NextSentence();
                SetSentenceSpeaker(_dialogue.GetSpeakerForSentence(sentence));
                StartCoroutine(TypeSentenceRoutine(sentence));
            }
            else
            {
                IsInUse = false;
                SetCompleteSentence(_dialogue.CurrentSentence());
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
            IsInUse = true;
            foreach (char letter in sentence.Phrase.ToCharArray())
            {
                EventManager.TriggerEvent(EventKeys.DialogueEvents.OnDialougeTypedLetter);
                _sentenceText.text += letter;
                yield return new WaitForSeconds(_displayLetterTime);
            }
            IsInUse = false;
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