namespace VUDK.Generic.Systems.MovementSystem.Interfaces
{
    using UnityEngine;

    public interface IMovement
    {
        public void Init(Rigidbody rigidBody, LayerMask groundLayers);
        public void Move();
        public void Stop();
        public void ResetMovement();
    }
}