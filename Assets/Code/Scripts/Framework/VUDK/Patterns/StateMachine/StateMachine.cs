namespace VUDK.Patterns.StateMachine
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class StateMachine : MonoBehaviour
    {
        protected Dictionary<Enum, State> States = new Dictionary<Enum, State>();

        public State CurrentState { get; private set; }

        private bool _isChanging;

        protected virtual void Start()
        {
            CurrentState?.Enter();
        }

        protected virtual void Update()
        {
            CurrentState?.Process();
        }

        protected virtual void FixedUpdate()
        {
            CurrentState?.PhysicsProcess();
        }

        /// <summary>
        /// Initializes the <see cref="StateMachine"/> and its states.
        /// </summary>
        public abstract void Init();

        /// <summary>
        /// Changes the state to a state in the dictionary by its key.
        /// </summary>
        /// <param name="stateKey">State key.</param>
        public void ChangeState(Enum stateKey)
        {
            if(_isChanging) return;
            if (States[stateKey] != CurrentState)
            {
                CurrentState?.Exit();
                CurrentState = States[stateKey];
                CurrentState?.Enter();
            }
        }

        /// <summary>
        /// Changes the state to a state in the dictionary by its key after waiting for seconds.
        /// </summary>
        /// <param name="stateKey">State key.</param>
        /// <param name="timeToWait">Time to wait in seconds.</param>
        public void ChangeState(Enum stateKey, float timeToWait)
        {
            if (_isChanging) return;
            StartCoroutine(WaitForSecondsChangeStateRoutine(stateKey, timeToWait));
        }

        /// <summary>
        /// Removes a state from the dictionary by its key.
        /// </summary>
        /// <param name="stateKey">State key.</param>
        public void RemoveState(Enum stateKey)
        {
            States.Remove(stateKey);
        }

        /// <summary>
        /// Adds a state.
        /// </summary>
        /// <param name="stateKey">State to add key.</param>
        /// <param name="state">State to add.</param>
        public void AddState(Enum stateKey, State state)
        {
            States.Add(stateKey, state);
        }

        /// <summary>
        /// Coroutine wait for seconds before changing state.
        /// </summary>
        /// <param name="stateKey">State Key.</param>
        /// <param name="time">Time in Seconds.</param>
        /// <returns></returns>
        private IEnumerator WaitForSecondsChangeStateRoutine(Enum stateKey, float time)
        {
            _isChanging = true;
            yield return new WaitForSeconds(time);
            _isChanging = false;
            ChangeState(stateKey);
        }
    }
}