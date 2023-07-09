namespace ProjectGenesis.Player.States.Factory
{
    using ProjectGenesis.Player.Controller;
    using VUDK.Patterns.StateMachine;
    
    public static class PlayerStatesFactory
    {
        public static State<PlayerContext> Create(PlayerStateKey stateKey, StateMachine relatedStateMachine, PlayerContext context)
        {
            switch (stateKey)
            {
                case PlayerStateKey.Air:
                    return new PlayerAirState(relatedStateMachine, context);

                case PlayerStateKey.Ground:
                    return new PlayerGroundState(relatedStateMachine, context);

                case PlayerStateKey.Jump:
                    return new PlayerJumpState(relatedStateMachine, context);
            }

            return null;
        }
    }
}