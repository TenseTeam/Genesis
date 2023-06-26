
namespace VUDK.Patterns.StateMachine
{
    using System;
    
    public class TestContext<TSubKey, TSubContext, TParentKey, TParentContext> : Context where TSubKey : Enum where TSubContext : Context where TParentKey : Enum where TParentContext : Context
    {
        public SubStateMachine<TSubKey, TSubContext, TParentKey, TParentContext> Sub;

        public TestContext(SubStateMachine<TSubKey, TSubContext, TParentKey, TParentContext> sub) : base()
        {
            Sub = sub;
        }
    }
}