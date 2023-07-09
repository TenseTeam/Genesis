namespace ProjectGenesis.UI.Menu
{
    using UnityEngine;
    using VUDK.Generic.Systems.InputSystem;

    public class MenuInputsController : MonoBehaviour
    {
        private void OnEnable()
        {
            InputsManager.Inputs.Disable();
        }

        private void OnDisable()
        {
            InputsManager.Inputs.Enable();
        }
    }
}
