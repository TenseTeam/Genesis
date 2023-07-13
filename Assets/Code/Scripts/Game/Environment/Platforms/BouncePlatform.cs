namespace ProjectGenesis.Environment.Platforms
{
    using UnityEngine;

    public class BouncePlatform : Platform
    {
        [SerializeField, Header("Bounce Force")]
        private float _bounceForce;

        protected override void OnEntityEnterPlatform(Collision entityCollision)
        {
            base.OnEntityEnterPlatform(entityCollision);
            Bounce(entityCollision.rigidbody);
        }

        private void Bounce(Rigidbody bouncer)
        {
            bouncer.velocity = Vector3.zero;
            bouncer.AddForce(transform.up * _bounceForce, ForceMode.Impulse);
        }
    }
}
