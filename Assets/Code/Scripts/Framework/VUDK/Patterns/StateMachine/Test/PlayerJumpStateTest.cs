namespace VUDK.Patterns.StateMachine
{
    using VUDK.Patterns.StateMachine.Interfaces;

    public class PlayerJumpStateTest : State<StatesKey, InputContext>
    {
        public PlayerJumpStateTest(StateMachine<StatesKey, InputContext> relatedStateMachine, InputContext context) : base(relatedStateMachine, context)
        {
        }

        public override void Enter()
        {
            if (Context.Inputs.PlayerMovement.Jump.IsPressed())
            {
                RelatedStateMachine.ChangeState(StatesKey.Walk);
            }
        }

        public override void Exit()
        {
        }

        public override void Process()
        {
        }
    }
}