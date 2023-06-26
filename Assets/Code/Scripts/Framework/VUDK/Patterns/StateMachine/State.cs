namespace VUDK.Patterns.StateMachine
{
    using System;
    using VUDK.Patterns.StateMachine.Interfaces;

    public abstract class State<TKey, TContext> : IEventState where TContext : Context where TKey : Enum
    {
        protected TContext Context;
        protected StateMachine<TKey, TContext> RelatedStateMachine;

        /// <summary>
        /// Initializes a new instance of the State class with the specified name and its associated <see cref="StateMachine"/>.
        /// </summary>
        /// <param name="name">The name of the state.</param>
        /// <param name="relatedStateMachine">The associated <see cref="StateMachine"/>.</param>
        protected State(StateMachine<TKey, TContext> relatedStateMachine, TContext context)
        {
            RelatedStateMachine = relatedStateMachine;
            Context = context;
        }

        /// <summary>
        /// Called when entering the state.
        /// </summary>
        public abstract void Enter();

        /// <summary>
        /// Called when exiting the state.
        /// </summary>
        public abstract void Exit();

        /// <summary>
        /// Called to process the state's logic.
        /// </summary>
        public abstract void Process();
    }
}