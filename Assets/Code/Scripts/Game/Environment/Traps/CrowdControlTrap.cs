namespace ProjectGenesis.Environment.Traps
{
    using UnityEngine;
    using VUDK.Generic.Systems.EntitySystem;
    using VUDK.Generic.Systems.EntitySystem.Interfaces;

    public class CrowdControlTrap : Trap
    {
        [SerializeField, Min(0f), Header("Rigidbody Mass")]
        private float _massMultiplier;

        private float _originalMass;

        protected override void OnEnterEntityTrap(Collider other, IEntity entity)
        {
            _originalMass = other.attachedRigidbody.mass;
            other.attachedRigidbody.mass = _massMultiplier;
        }

        protected override void OnExitEntityTrap(Collider other, IEntity entity)
        {
            other.attachedRigidbody.mass = _originalMass;
        }
    }
}