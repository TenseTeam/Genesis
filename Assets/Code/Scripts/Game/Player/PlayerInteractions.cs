namespace ProjectGenesis.Player
{
    using UnityEngine.InputSystem;
    using VUDK.Features.DialogueSystem;
    using VUDK.Generic.Managers;
    using VUDK.Generic.Systems.InputSystem;
    using VUDK.Generic.Systems.InteractSystem;

    public class PlayerInteractions : InteractorBase
    {
        private DialogueManager _dialogueManager;

        private void Awake()
        {
            _dialogueManager = GameManager.Instance.DialogueManager;
        }

        private void OnEnable()
        {
            InputsManager.Inputs.Dialogue.SkipSentence.started += SkipDialogue;
            InputsManager.Inputs.PlayerInteract.Interact.started += TriggerInteract;
        }

        private void OnDisable()
        {
            InputsManager.Inputs.Dialogue.SkipSentence.started -= SkipDialogue;
            InputsManager.Inputs.PlayerInteract.Interact.started -= TriggerInteract;
        }

        private void SkipDialogue(InputAction.CallbackContext obj)
        {
            if (_dialogueManager.IsDialogueOpen)
                _dialogueManager.DisplayNextSentence();
        }

        private void TriggerInteract(InputAction.CallbackContext context)
        {
            TriggerInteractable();
        }
    }
}