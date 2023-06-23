namespace ProjectGenesis.Managers
{
    using UnityEngine;

    public class InputsManager : MonoBehaviour
    {
        public static Inputs Inputs;

        private void Awake()
        {
            Inputs = new Inputs();
            Inputs.Enable();
        }
    }
}
