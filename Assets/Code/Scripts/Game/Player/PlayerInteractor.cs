namespace ProjectGenesis.Player
{
    using UnityEngine.InputSystem;
    using VUDK.Generic.Systems.InputSystem;
    using VUDK.Generic.Systems.InteractSystem;

    public class PlayerInteractor : InteractorBase
    {
        private void OnEnable()
        {
            InputsManager.Inputs.PlayerInteract.Interact.started += TriggerInteract;
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