namespace VUDK.Patterns.StateMachine
{
    using System;

    public abstract class SubStateMachine<TSubKey, TSubContext, TParentKey, TParentContext> : StateMachine<TSubKey, TSubContext>
        where TSubKey : Enum where TSubContext : Context
        where TParentKey : Enum where TParentContext : Context
    {
        public StateMachine<TParentKey, TParentContext> ParentStateMachine { get; private set; }

        /// <summary>
        /// Initializes the <see cref="SubStateMachine{ParentKey, ParentContext, TKey, TContext}"/>.
        /// </summary>
        /// <param name="parentStateMachine">Parent <see cref="StateMachine{TKey, TContext}"/>.</param>
        public virtual void Init(StateMachine<TParentKey, TParentContext> parentStateMachine)
        {
            ParentStateMachine = parentStateMachine;
            Init();
        }
    }
}