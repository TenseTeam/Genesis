namespace ProjectGenesis.Player
{
    using System;
    using System.Collections;
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

        protected float Horizontal;
        protected bool PreviousIsGroundedState;
        protected bool IsJumpInCooldown;
        protected bool IsRotating;

        private Quaternion _targetRotation;

        public event Action<float> OnMovement;

        public event Action<bool> OnFalling;

        public event Action OnJump;

        private void OnEnable()
        {
            InputsManager.Inputs.PlayerMovement.Jump.started += Jump;
            InputsManager.Inputs.PlayerMovement.Movement.started += StartMoving;
            InputsManager.Inputs.PlayerMovement.Movement.performed += PerformMoving;
            InputsManager.Inputs.PlayerMovement.Movement.canceled += StopMoving;
        }

        private void OnDisable()
        {
            InputsManager.Inputs.PlayerMovement.Jump.started -= Jump;
            InputsManager.Inputs.PlayerMovement.Movement.started -= StartMoving;
            InputsManager.Inputs.PlayerMovement.Movement.performed -= PerformMoving;
            InputsManager.Inputs.PlayerMovement.Movement.canceled -= StopMoving;
        }

        private void FixedUpdate()
        {
            Move();
            Rotate();
        }

        private void Update()
        {
            CheckIsGroundedState();
        }

        public override void ResetMovement()
        {
            Horizontal = 0f;
            PreviousIsGroundedState = false;
            IsJumpInCooldown = false;
            IsRotating = false;
        }

        public override void Move()
        {
            if (IsWalled) return;

            float currentSpeed = IsGrounded ? GroundSpeed : AirSpeed;
            Rigidbody.velocity = new Vector3(Rigidbody.velocity.x, Rigidbody.velocity.y, Horizontal * currentSpeed);
        }

        public override void Stop()
        {
            Horizontal = 0f;
            OnMovement?.Invoke(Horizontal);
        }

        private void StartMoving(InputAction.CallbackContext input)
        {
            float direction = input.ReadValue<float>();
            CalculateTargetRotation(direction);
            IsRotating = true;
        }

        private void PerformMoving(InputAction.CallbackContext input)
        {
            Horizontal = input.ReadValue<float>();
            OnMovement?.Invoke(Horizontal);
        }

        private void StopMoving(InputAction.CallbackContext input)
        {
            Stop();
            IsRotating = false;
        }

        private void Jump(InputAction.CallbackContext input)
        {
            if (IsGrounded && !IsJumpInCooldown)
            {
                OnJump?.Invoke();
                Rigidbody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
                StartCoroutine(JumpCooldownRoutine());
            }
        }

        private void CheckIsGroundedState()
        {
            if (IsGrounded != PreviousIsGroundedState)
            {
                OnFalling?.Invoke(!IsGrounded);
                PreviousIsGroundedState = IsGrounded;
            }
        }

        private void Rotate()
        {
            if (IsRotating)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, _rotationSpeed);
            }
        }

        private void CalculateTargetRotation(float direction)
        {
            _targetRotation = Quaternion.Euler(transform.eulerAngles.x, direction >= 0f ? 0f : 180f, transform.eulerAngles.z);
        }

        private IEnumerator JumpCooldownRoutine()
        {
            IsJumpInCooldown = true;
            yield return new WaitForSeconds(_jumpCooldown);
            IsJumpInCooldown = false;
        }
    }
}