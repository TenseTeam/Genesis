namespace ProjectGenesis.Player
{
    using ProjectGenesis.Constants.Events;
    using System;
    using UnityEngine;
    using VUDK.Extensions.Transform;
    using VUDK.Generic.Managers;
    using VUDK.Generic.Systems.CheckpointSystem;
    using VUDK.Generic.Systems.EntitySystem;
    using VUDK.Generic.Systems.EventsSystem;

    public class PlayerEntity : EntityBase
    {
        private PlayerController _manager;
        private Vector3 _startPosition;

        private void OnEnable()
        {
            OnHitPointsSetUp += (current, max) => GameManager.Instance.EventManager.TriggerEvent(EventKeys.OnHitPointsPlayerSetup, (int)current, (int)max);
            OnTakeDamage += () => GameManager.Instance.EventManager.TriggerEvent(EventKeys.OnPlayerTakeDamage);
        }

        private void OnDisable()
        {
            OnHitPointsSetUp -= (current, max) => GameManager.Instance.EventManager.TriggerEvent(EventKeys.OnHitPointsPlayerSetup, (int)current, (int)max);
            OnTakeDamage -= () => GameManager.Instance.EventManager.TriggerEvent(EventKeys.OnPlayerTakeDamage);
        }

        public void Init(PlayerController manager, Vector3 _startPosition)
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
            GameManager.Instance.EventManager.TriggerEvent(EventKeys.OnGameover);
        }
    }
}
