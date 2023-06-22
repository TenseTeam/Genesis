namespace VUDK.Patterns.StateMachine
{
    using VUDK.Patterns.StateMachine.Interfaces;

    public abstract class LinkedTurnState : State
    {
        public TurnStateMachine RelatedStateMachine { get; private set; }

        /// <summary>
        /// Initializes a new instance of the State class with the specified name.
        /// </summary>
        /// <param name="name">Name of the state.</param>
        protected LinkedTurnState(string name, TurnStateMachine relatedStateMachine) : base(name)
        {
            RelatedStateMachine = relatedStateMachine;
        }
    }
}