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

        protected override void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.TryGetComponent(out IEntity entity))
                Bounce(collision.rigidbody);
        }

        private void Bounce(Rigidbody interactor)
        {
            interactor.velocity = Vector3.zero;
            interactor.AddForce(_direction.GetDirection() * _bounceForce, ForceMode.Impulse);
        }
    }
}
