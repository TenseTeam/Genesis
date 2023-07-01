namespace ProjectGenesis.Player.States
{
    using VUDK.Patterns.StateMachine;
    using ProjectGenesis.Player.Controller;

    public class PlayerJumpState : State<PlayerContext>
    {
        public PlayerJumpState(StateMachine relatedStateMachine, Context context) : base(relatedStateMachine, context)
        {
        }

        public override void Enter()
        {
            Context.PlayerMovement.Jump();
            Context.Graphics.AnimateJump();
            Context.PlayerMovement.SetIsJumpInCoolDown(true);
            ChangeState(PlayerStateKey.Air, .2f);
        }

        public override void Exit()
        {
            Context.PlayerMovement.StartJumpCooldown();
        }

        public override void PhysicsProcess()
        {
        }

        public override void Process()
        {
        }
    }
}