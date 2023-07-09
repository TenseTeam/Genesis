namespace ProjectGenesis.Player.States
{
    using UnityEngine.InputSystem;
    using ProjectGenesis.Player.Controller;
    using VUDK.Patterns.StateMachine;

    public class PlayerGroundState : State<PlayerContext>
    {
        public PlayerGroundState(StateMachine relatedStateMachine, Context context) : base(relatedStateMachine, context)
        {
            Context.Inputs.PlayerMovement.Jump.started += ChangeToJump;
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

        private void ChangeToJump(InputAction.CallbackContext context)
        {
            if (!Context.PlayerMovement.IsJumpInCooldown)
                ChangeState(PlayerStateKey.Jump);
        }
    }
}
