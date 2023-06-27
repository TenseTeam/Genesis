namespace VUDK.Patterns.StateMachine
{
    public class InputContext : Context
    {
        public Inputs Inputs { get; protected set; }

        public InputContext(Inputs inputs) : base()
        {
            Inputs = inputs;
        }
    }
}