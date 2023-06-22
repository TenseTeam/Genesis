namespace VUDK.Patterns.StateMachine
{
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class StateMachine : MonoBehaviour
    {
        public State CurrentState { get; private set; }

        public int CurrentStateKey { get; protected set; } = 0;

        protected List<State> States { get; set; }

        /// <summary>
        /// Initializes the states list.
        /// </summary>
        protected virtual void InitStates()
        {
            States = new List<State>();
        }

        protected virtual void Start()
        {
            CurrentState?.Enter();
        }

        protected virtual void Update()
        {
            CurrentState?.Process();
        }

        /// <summary>
        /// Changes the state to a state in the list by its index.
        /// </summary>
        /// <param name="stateKey">State key.</param>
        public void ChangeState(int stateKey)
        {
            if (States[stateKey] != CurrentState)
            {
                CurrentState?.Exit();
                CurrentStateKey = stateKey;
                CurrentState = States[stateKey];
                CurrentState?.Enter();
            }
        }

        /// <summary>
        /// Removes a state from the states list by its index.
        /// </summary>
        /// <param name="stateKey">State key.</param>
        public void RemoveState(int stateKey)
        {
            States.RemoveAt(stateKey);
        }

        /// <summary>
        /// Removes a state from the states list.
        /// </summary>
        /// <param name="stateKey">State.</param>

        public void RemoveState(State state)
        {
            if(!States.Contains(state))
                return;

            States.Remove(state);
        }

        /// <summary>
        /// Adds a state to the states list.
        /// </summary>
        /// <param name="state">State to add.</param>
        public void AddState(State state)
        {
            States.Add(state);
        }

        /// <summary>
        /// Begins the state machine starting from the state of index 0.
        /// </summary>
        public virtual void Begin()
        {
            ChangeState(0);
        }
    }
}