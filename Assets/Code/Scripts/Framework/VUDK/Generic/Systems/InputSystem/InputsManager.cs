namespace VUDK.Generic.Systems.InputSystem
{
    using UnityEngine;

    public class InputsManager
    {
        public static Inputs Inputs;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        private static void LoadInputs()
        {
            Inputs = new Inputs();
            Inputs.Enable();
        }
    }
}
