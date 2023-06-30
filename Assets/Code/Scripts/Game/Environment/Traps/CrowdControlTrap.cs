namespace ProjectGenesis.Environment.Traps
{
    using UnityEngine;
    using VUDK.Generic.Systems.EntitySystem;

    public class CrowdControlTrap : Trap
    {
        [SerializeField, Min(0f), Header("Rigidbody Mass")]
        private float _massMultiplier;

        private float _originalMass;

        protected override void OnEnterEntityTrap(Collider other, EntityBase entity)
        {
            _originalMass = other.attachedRigidbody.mass;
            other.attachedRigidbody.mass = _massMultiplier;
        }

        protected override void OnExitEntityTrap(Collider other, EntityBase entity)
        {
            other.attachedRigidbody.mass = _originalMass;
        }
    }
}