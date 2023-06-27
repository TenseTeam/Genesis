namespace ProjectGenesis.Player
{
    using System;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using VUDK.Generic.Systems.InputSystem;
    using VUDK.Generic.Systems.MovementSystem;

    public class PlayerMovement : MovementBase
    {
        [SerializeField, Header("Rotation"), Range(0.01f, 1f)]
        private float _rotationSpeed;

        [SerializeField, Min(0), Header("Jump")]
        private float _jumpForce;

        [SerializeField, Min(0)]
        private float _jumpCooldown;

        private Quaternion _targetRotation;

        [field: SerializeField, Header("Speeds")]
        public float GroundSpeed { get; private set; }

        [field: SerializeField]
        public float AirSpeed { get; private set; }

        public float Horizontal { get; private set; }

        private bool _isRotating;

        private void OnEnable()
        {
            InputsManager.Inputs.PlayerMovement.Jump.started += Jump;
            InputsManager.Inputs.PlayerMovement.Movement.performed += PerformMoving;
            InputsManager.Inputs.PlayerMovement.Movement.canceled += StopMoving;
        }

        private void OnDisable()
        {
            InputsManager.Inputs.PlayerMovement.Jump.started -= Jump;
            InputsManager.Inputs.PlayerMovement.Movement.performed -= PerformMoving;
            InputsManager.Inputs.PlayerMovement.Movement.canceled -= StopMoving;
        }

        private void FixedUpdate()
        {
            Move();
            Rotate();
        }

        public override void Move()
        {
            Rigidbody.velocity = new Vector3(Rigidbody.velocity.x, Rigidbody.velocity.y, Horizontal * Speed);
        }

        public override void Stop()
        {
            Horizontal = 0f;
        }

        private void PerformMoving(InputAction.CallbackContext input)
        {
            Horizontal = input.ReadValue<float>();
            CalculateTargetRotation(Horizontal);
            _isRotating = true;
        }

        private void StopMoving(InputAction.CallbackContext input)
        {
            Stop();
            _isRotating = false;
        }

        private void Jump(InputAction.CallbackContext input)
        {
            Rigidbody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);   
        }

        private void Rotate()
        {
            if(_isRotating)
                transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, _rotationSpeed);
        }

        private void CalculateTargetRotation(float direction)
        {
            _targetRotation = Quaternion.Euler(transform.eulerAngles.x, direction >= 0f ? 0f : 180f, transform.eulerAngles.z);
        }
    }
}