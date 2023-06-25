namespace ProjectGenesis.Player.Interfaces
{
    using ProjectGenesis.Player;

    public interface IPlayerManager
    {
        public PlayerMovement Movement { get; }
        public PlayerGraphicsController Graphics { get; }
        public PlayerEntity Entity { get; }
        public PlayerStatus Status { get; }
    }
}