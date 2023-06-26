namespace VUDK.Patterns.StateMachine
{
    public class InputContext : Context
    {
        public Inputs Inputs;

        public InputContext(Inputs inputs) : base()
        {
            Inputs = inputs;
        }
    }
}