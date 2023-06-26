namespace ProjectGenesis.Player
{
    using UnityEngine;
    using VUDK.Extensions.Transform;
    using VUDK.Generic.Systems.CheckpointSystem;
    using VUDK.Generic.Systems.EntitySystem;

    public class PlayerEntity : EntityBase
    {
        private PlayerManager _manager;
        private Vector3 _startPosition;

        public void Init(PlayerManager manager, Vector3 _startPosition)
        {
            base.Init();
            _manager = manager;
        }

        public override void TakeDamage(float hitDamage = 1)
        {
            base.TakeDamage(hitDamage);

            _manager.Reset();

            // warnig -> this way when it's splitted the splitted version will disable itself but the player will be still present. Gameover needed.
            if (IsAlive)
            {
                if(CheckpointsManager.TryGetLastCheckpoint(this, out Vector3 respawnPosition))
                    transform.SetPosition(respawnPosition);
                else
                    transform.SetPosition(_startPosition);
            }
        }

        protected override void DeathEffects()
        {
            Debug.Log("Gameover!"); //TO DO -> What happen on Gameover?
        }
    }
}
