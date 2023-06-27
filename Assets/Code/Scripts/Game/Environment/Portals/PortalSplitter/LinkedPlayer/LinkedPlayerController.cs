namespace ProjectGenesis.Environment.Portals
{
    using VUDK.Extensions.Transform;
    using VUDK.Generic.Systems.EntitySystem.Interfaces;
    using VUDK.Generic.Systems.InputSystem;
    using ProjectGenesis.Settings;
    using ProjectGenesis.Player;

    public class LinkedPlayerController : PlayerController, IEntity
    {
        private bool _areStatesInitialized;

        protected override void Awake()
        {
            TryGetComponent(out PlayerMovement movement);
            TryGetComponent(out PlayerGraphicsController graphics);
            TryGetComponent(out PlayerStatus status);
            TryGetComponent(out Rigidbody);
            TryGetComponent(out Animator);

            Movement = movement;
            Graphics = graphics;
            Status = status;

            Movement.Init(Rigidbody, GameSettings.GroundLayers);
            Graphics.Init(Animator);
        }

        public void Init(PlayerController realPlayer)
        {
            Status = realPlayer.Status;
            Entity = realPlayer.Entity;
            InputsManager.Inputs.Disable();
            InputsManager.Inputs.Enable();
            SetAsRealPlayer(realPlayer);
            gameObject.SetActive(true);

            if (!_areStatesInitialized)
            {
                Init();
                _areStatesInitialized = true;
            }
        }

        public void HealHitPoints(float healPoints)
        {
            Entity.HealHitPoints(healPoints);
        }

        public void TakeDamage(float hitDamage = 1)
        {
            gameObject.SetActive(false);
            Entity.TakeDamage(hitDamage);
        }

        public void Death()
        {
            Entity.Death();
        }

        private void SetAsRealPlayer(PlayerController realPlayer)
        {
            transform.SetLossyScale(realPlayer.transform.lossyScale);
        }
    }
}