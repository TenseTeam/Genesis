namespace ProjectGenesis.Player
{
    using UnityEngine;
    using VUDK.Generic.Systems.EventsSystem;
    using VUDK.Generic.Systems.InputSystem;
    using EventKeysVUDK = VUDK.Generic.Systems.EventsSystem.Events.EventKeys;
    using EventKeys = ProjectGenesis.Constants.Events.EventKeys;
    using VUDK.Generic.Managers;

    public class PlayerInputsController : MonoBehaviour
    {
        private void OnEnable()
        {
            GameManager.Instance.EventManager.AddListener(EventKeysVUDK.DialogueEvents.OnStartDialogue, EnableOnlyDialogueInputs);
            GameManager.Instance.EventManager.AddListener(EventKeysVUDK.DialogueEvents.OnEndDialogue, EnableInputs);
            //EventManager.AddListener(EventKeys.OnGameover, DisableInputs); Not necessary if I use MenuInputsController on the Gameover scene
        }

        private void OnDisable()
        {
            GameManager.Instance.EventManager.RemoveListener(EventKeysVUDK.DialogueEvents.OnStartDialogue, EnableOnlyDialogueInputs);
            GameManager.Instance.EventManager.RemoveListener(EventKeysVUDK.DialogueEvents.OnEndDialogue, EnableInputs);
            //EventManager.RemoveListener(EventKeys.OnGameover, DisableInputs);
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