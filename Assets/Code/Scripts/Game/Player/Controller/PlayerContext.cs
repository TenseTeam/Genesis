namespace ProjectGenesis.Player.Controller
{
    using VUDK.Patterns.StateMachine;

    public class PlayerContext : InputContext
    {
        public PlayerGraphicsController Graphics { get; private set; }
        public PlayerMovement PlayerMovement { get; private set; }

        public PlayerContext(Inputs inputs, PlayerMovement playerMovement, PlayerGraphicsController graphics) : base(inputs)
        {
            PlayerMovement = playerMovement;
            Graphics = graphics;
        }
    }
}