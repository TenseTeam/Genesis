namespace ProjectGenesis.Player
{
    using UnityEngine;
    using VUDK.Generic.Systems.EventsSystem;
    using VUDK.Generic.Systems.EventsSystem.Events;
    using VUDK.Generic.Systems.InputSystem;

    public class PlayerInputsController : MonoBehaviour
    {
        private void OnEnable()
        {
            EventManager.AddListener(EventKeys.DialogueEvents.OnStartDialogue, EnableOnlyDialogueInputs);
            EventManager.AddListener(EventKeys.DialogueEvents.OnEndDialogue, EnableInputs);
        }

        private void OnDisable()
        {
            EventManager.RemoveListener(EventKeys.DialogueEvents.OnStartDialogue, EnableOnlyDialogueInputs);
            EventManager.RemoveListener(EventKeys.DialogueEvents.OnEndDialogue, EnableInputs);
        }

        private void EnableInputs()
        {
            InputsManager.Inputs.Enable();
        }

        private void DisableInputs()
        {
            InputsManager.Inputs.Disable();
        }

        private void EnableMovementInputs()
        {
            InputsManager.Inputs.PlayerMovement.Enable();
        }

        private void DisableMovementInputs()
        {
            InputsManager.Inputs.PlayerMovement.Disable();
        }

        private void EnableOnlyDialogueInputs()
        {
            DisableInputs();
            InputsManager.Inputs.Dialogue.Enable();
        }
    }
}