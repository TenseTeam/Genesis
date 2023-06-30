namespace ProjectGenesis.Environment.Platforms
{
    using UnityEngine;
    using VUDK.Generic.Systems.EntitySystem.Interfaces;
    using VUDK.Extensions.Vectors;

    public class BouncePlatform : Platform
    {
        [SerializeField, Header("Bounce Force")]
        private float _bounceForce;
        [SerializeField]
        private Vector3Direction _direction;

        protected override void OnEntityEnterPlatform(Collision entityCollision)
        {
            base.OnEntityEnterPlatform(entityCollision);
            Bounce(entityCollision.rigidbody);
        }

        private void Bounce(Rigidbody bouncer)
        {
            bouncer.velocity = Vector3.zero;
            bouncer.AddForce(_direction.GetDirection() * _bounceForce, ForceMode.Impulse);
        }
    }
}
