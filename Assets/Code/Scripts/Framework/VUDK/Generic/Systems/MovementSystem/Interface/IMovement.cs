namespace VUDK.Generic.Systems.MovementSystem.Interfaces
{
    using System;
    using UnityEngine;

    public interface IMovement
    {
        public bool IsGrounded { get; }

        public void Init(Rigidbody rigidBody);

        public void Move();

        public void Stop();
    }
}