namespace VUDK.Patterns.StateMachine
{
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class SubTurnStateMachine : TurnStateMachine
    {
        public TurnStateMachine ParentStateMachine { get; private set; }

        protected virtual void InitStates(TurnStateMachine parentStateMachine)
        {
            ParentStateMachine = parentStateMachine;
            InitStates();
        }
    }
}