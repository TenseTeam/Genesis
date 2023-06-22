namespace VUDK.Patterns.StateMachine
{
    using VUDK.Patterns.StateMachine.Interfaces;

    public abstract class LinkedState : State
    {
        public StateMachine RelatedStateMachine { get; private set; }

        /// <summary>
        /// Initializes a new instance of the State class with the specified name.
        /// </summary>
        /// <param name="name">Name of the state.</param>
        protected LinkedState(string name, StateMachine relatedStateMachine) : base(name)
        {
            RelatedStateMachine = relatedStateMachine;
        }
    }
}