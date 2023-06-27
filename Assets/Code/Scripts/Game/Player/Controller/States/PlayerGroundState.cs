namespace ProjectGenesis.Player.States
{
    using VUDK.Patterns.StateMachine;
    using ProjectGenesis.Player.Controller;

    public class PlayerGroundState : State<PlayerContext>
    {
        public PlayerGroundState(StateMachine relatedStateMachine, Context context) : base(relatedStateMachine, context)
        {
        }

        public override void Enter()
        {
            Context.PlayerMovement.SetSpeed(Context.PlayerMovement.GroundSpeed);
        }

        public override void Exit()
        {
        }

        public override void PhysicsProcess()
        {
        }

        public override void Process()
        {
            Context.Graphics.AnimateMovement(Context.PlayerMovement.Horizontal);

            if (!Context.PlayerMovement.IsGrounded)
                ChangeState(PlayerStateKey.Air);
        }
    }
}
