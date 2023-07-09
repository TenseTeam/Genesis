namespace ProjectGenesis.Generic.Factories
{
    using VUDK.Patterns.StateMachine;
    using ProjectGenesis.Player;
    using ProjectGenesis.Player.Controller;

    public static class ContextFactory
    {
        public static InputContext Create(Inputs inputs)
        {
            return new InputContext(inputs);
        }

        public static PlayerContext Create(Inputs inputs, PlayerMovement playerMovement, PlayerGraphicsController graphics)
        {
            return new PlayerContext(inputs, playerMovement, graphics);
        }
    }
}