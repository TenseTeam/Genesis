namespace VUDK.Patterns.StateMachine
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class StateMachine<TKey, TContext> : MonoBehaviour where TContext : Context where TKey : Enum
    {
        protected Dictionary<TKey, State<TKey, TContext>> States = new Dictionary<TKey, State<TKey, TContext>>();

        public TKey CurrentStateKey { get; protected set; }

        public State<TKey, TContext> CurrentState { get; private set; }

        protected virtual void Start()
        {
            CurrentState?.Enter();
        }

        protected virtual void Update()
        {
            CurrentState?.Process();
        }

        /// <summary>
        /// Initializes the <see cref="StateMachine"/> and its states.
        /// </summary>
        public abstract void Init();

        /// <summary>
        /// Changes the state to a state in the list by its key.
        /// </summary>
        /// <param name="stateKey">State key.</param>
        public void ChangeState(TKey stateKey)
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
        /// Changes the state to a state in the list by its key after waiting for seconds.
        /// </summary>
        /// <param name="stateKey">State key.</param>
        /// <param name="timeToWait">Time to wait in seconds.</param>
        public void ChangeStateIn(TKey stateKey, float timeToWait)
        {
            StartCoroutine(WaitSecondsAndGoToStateRoutine(stateKey, timeToWait));
        }

        /// <summary>
        /// Removes a state from the states by its key.
        /// </summary>
        /// <param name="stateKey">State key.</param>
        public void RemoveState(TKey stateKey)
        {
            States.Remove(stateKey);
        }

        /// <summary>
        /// Adds a state.
        /// </summary>
        /// <param name="stateKey">State to add key.</param>
        /// <param name="state">State to add.</param>
        public void AddState(TKey stateKey, State<TKey, TContext> state)
        {
            States.Add(stateKey, state);
        }

        /// <summary>
        /// Coroutine wait for seconds before changing state.
        /// </summary>
        /// <param name="stateKey">State Key.</param>
        /// <param name="time">Time in Seconds.</param>
        /// <returns></returns>
        private IEnumerator WaitSecondsAndGoToStateRoutine(TKey stateKey, float time)
        {
            yield return new WaitForSeconds(time);
            ChangeState(stateKey);
        }
    }
}