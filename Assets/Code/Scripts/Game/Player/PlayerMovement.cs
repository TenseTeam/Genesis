﻿namespace ProjectGenesis.Player
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using VUDK.Generic.Systems.EventsSystem;
    using VUDK.Generic.Systems.MovementSystem;
    using ProjectGenesis.Managers;
    using ProjectGenesis.Events;

    public class PlayerMovement : MovementBase
    {
        [SerializeField, Header("Rotation"), Range(0.01f, 1f)]
        private float _rotationSpeed;

        [SerializeField, Min(0), Header("Jump")]
        private float _jumpForce;
        [SerializeField, Min(0)]
        private float _jumpCooldown;

        private float _horizontal;
        private bool _previousIsGroundedState;
        private float _rotationDirection;
        private bool _isJumpInCooldown;

        private void OnEnable()
        {
            InputsManager.Inputs.PlayerMovement.Jump.started += Jump;
            InputsManager.Inputs.PlayerMovement.Movement.started += StartMoving;
            InputsManager.Inputs.PlayerMovement.Movement.canceled += StopMoving;
        }

        private void OnDisable()
        {
            InputsManager.Inputs.PlayerMovement.Jump.started -= Jump;
            InputsManager.Inputs.PlayerMovement.Movement.started -= StartMoving;
            InputsManager.Inputs.PlayerMovement.Movement.canceled -= StopMoving;
        }

        private void FixedUpdate()
        {
            Move();
            Rotate(_rotationDirection);
        }

        private void Update()
        {
            CheckIsGroundedState();
        }

        public override void Move()
        {
            if(IsWalled) return;

            float currentSpeed = IsGrounded ? GroundSpeed : AirSpeed;
            Rigidbody.velocity = new Vector3(Rigidbody.velocity.x, Rigidbody.velocity.y, _horizontal * currentSpeed);
        }

        public override void Stop()
        {
            _horizontal = 0f;
            StopAllCoroutines();
            EventManager.TriggerEvent(Events.PlayerEvents.OnMovement, _horizontal);
        }

        private void StartMoving(InputAction.CallbackContext input)
        {
            _horizontal = input.ReadValue<float>();
            _rotationDirection = _horizontal;
            EventManager.TriggerEvent(Events.PlayerEvents.OnMovement, _horizontal);
        }

        private void StopMoving(InputAction.CallbackContext input)
        {
            Stop();
        }

        private void Jump(InputAction.CallbackContext input)
        {
            if (IsGrounded && !_isJumpInCooldown)
            {
                EventManager.TriggerEvent(Events.PlayerEvents.OnJump);
                Rigidbody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
                JumpCooldown();
            }
        }

        private void CheckIsGroundedState()
        {
            if (IsGrounded != _previousIsGroundedState)
            {
                EventManager.TriggerEvent(Events.PlayerEvents.OnFalling, !IsGrounded);
                _previousIsGroundedState = IsGrounded;
            }
        }

        private void JumpCooldown()
        {
            _isJumpInCooldown = true;
            Invoke("RecoverJump", _jumpCooldown);
        }

        private void RecoverJump()
        {
            _isJumpInCooldown = false;
        }

        private void Rotate(float direction)
        {
            Quaternion targetRotation = Quaternion.Euler(0f, direction >= 0f ? 0f : 180f, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotationSpeed);
        }
    }
}