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

        public void EnableInputs()
        {
            InputsManager.Inputs.Enable();
        }

        public void DisableInputs()
        {
            InputsManager.Inputs.Disable();
        }

        public void EnableMovementInputs()
        {
            InputsManager.Inputs.PlayerMovement.Enable();
        }

        public void DisableMovementInputs()
        {
            InputsManager.Inputs.PlayerMovement.Disable();
        }

        public void EnableOnlyDialogueInputs()
        {
            DisableInputs();
            InputsManager.Inputs.Dialogue.Enable();
        }
    }
}