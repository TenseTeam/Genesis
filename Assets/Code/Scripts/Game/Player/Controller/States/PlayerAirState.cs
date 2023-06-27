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
            Context.PlayerMovement.SetSpeed(Context.PlayerMovement.AirSpeed);
            Context.Graphics.AnimateJump();
            Context.Graphics.AnimateFalling(true);
            Context.Inputs.PlayerMovement.Jump.Disable();
        }

        public override void Exit()
        {
            Context.Inputs.PlayerMovement.Jump.Enable();
            Context.Graphics.AnimateFalling(false);
        }

        public override void PhysicsProcess()
        {
        }

        public override void Process()
        {
            //if (Context.PlayerMovement.IsWalled)
            //{
            //    Context.PlayerMovement.Stop();
            //}

            if (Context.PlayerMovement.IsGrounded)
                ChangeState(PlayerStateKey.Ground);
        }
    }
}