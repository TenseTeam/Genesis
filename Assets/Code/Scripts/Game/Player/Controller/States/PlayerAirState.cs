namespace ProjectGenesis.Player.States
{
    using VUDK.Patterns.StateMachine;
    using ProjectGenesis.Player.Controller;

    public class PlayerAirState : State<PlayerContext>
    {
        public PlayerAirState(StateMachine relatedStateMachine, Context context) : base(relatedStateMachine, context)
        {
        }

        public override void Enter()
        {
            Context.Graphics.AnimateFalling(true);
            Context.PlayerMovement.SetSpeed(Context.PlayerMovement.AirSpeed);
            Context.Inputs.PlayerMovement.Jump.Disable();
        }

        public override void Exit()
        {
            Context.Graphics.AnimateFalling(false);
            Context.PlayerMovement.StartJumpCooldown();
            Context.Inputs.PlayerMovement.Jump.Enable();
        }

        public override void PhysicsProcess()
        {
        }

        public override void Process()
        {
            if (Context.PlayerMovement.IsGrounded)
                ChangeState(PlayerStateKey.Ground);
        }
    }
}