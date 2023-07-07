namespace VUDK.Generic.Systems.EntitySystem
{
    using System;
    using UnityEngine;
    using VUDK.Generic.Systems.EntitySystem.Interfaces;

    public abstract class EntityBase : MonoBehaviour, IEntity
    {
        [SerializeField, Min(0)]
        protected float StartingHitPoints;

        [field: SerializeField, Min(0)]
        public float MaxHitPoints { get; protected set; }
        public float CurrentHitPoints { get; private set; }
        public bool IsAlive { get; private set; } = true;

        public event Action<float, float, float> OnChangeHitPoints;
        public event Action<float, float> OnHitPointsSetUp;
        public event Action OnTakeDamage;
        public event Action OnHealHitPoints;
        public event Action OnDeath;

        public virtual void Init()
        {
            IsAlive = true;
            CurrentHitPoints = StartingHitPoints;

            if (CurrentHitPoints > StartingHitPoints)
            {
                StartingHitPoints = MaxHitPoints;
                CurrentHitPoints = StartingHitPoints;
            }

            OnHitPointsSetUp?.Invoke(CurrentHitPoints, MaxHitPoints);
        }

        public virtual void TakeDamage(float hitDamage = 1f)
        {
            OnTakeDamage?.Invoke();

            CurrentHitPoints -= Mathf.Abs(hitDamage);

            if (CurrentHitPoints <= 0.1f)
            {
                CurrentHitPoints = 0f;
                Death();
            }

            OnChangeHitPoints?.Invoke(hitDamage, CurrentHitPoints, MaxHitPoints);
        }

        public virtual void HealHitPoints(float healPoints)
        {
            OnHealHitPoints?.Invoke();

            IsAlive = true;
            CurrentHitPoints += Mathf.Abs(healPoints);

            if (CurrentHitPoints > MaxHitPoints)
                CurrentHitPoints = MaxHitPoints;

            OnChangeHitPoints?.Invoke(healPoints, CurrentHitPoints, MaxHitPoints);
        }

        public void Death()
        {
            if (IsAlive)
            {
                IsAlive = false;
                DeathEffects();   
                OnDeath?.Invoke();
            }
        }

        /// <summary>
        /// Triggers the effects of death.
        /// </summary>
        protected abstract void DeathEffects();
    }
}