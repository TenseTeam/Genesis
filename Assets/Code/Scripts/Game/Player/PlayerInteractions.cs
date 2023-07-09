namespace ProjectGenesis.Player
{
    using System;
    using UnityEngine.InputSystem;
    using VUDK.Features.DialogueSystem;
    using VUDK.Generic.Managers;
    using VUDK.Generic.Systems.EventsSystem;
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
            InputsManager.Inputs.UI.NextDialogue.started += SkipDialogue;
            InputsManager.Inputs.PlayerInteract.Interact.started += TriggerInteract;
            //EventManager.AddListener();
        }

        private void SkipDialogue(InputAction.CallbackContext obj)
        {
            if (_dialogueManager.IsInUse)
            {
                _dialogueManager.DisplayNextSentence();
            }
        }

        private void OnDisable()
        {
            InputsManager.Inputs.PlayerInteract.Interact.started -= TriggerInteract;            
        }

        private void TriggerInteract(InputAction.CallbackContext context)
        {
            TriggerInteractable();
        }
    }
}