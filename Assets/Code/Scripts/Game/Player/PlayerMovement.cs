namespace ProjectGenesis.Player
{
    using ProjectGenesis.Constants.Events;
    using System;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using VUDK.Generic.Managers;
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

        //[SerializeField, Header("Scale")]
        //private bool _isJumpAffectedByScale;
        //[SerializeField]
        //private bool _isSpeedAffectedByScale;

        //[SerializeField, Range(0f, 90f), Header("Slope")]
        //private float _maxSlopeDegree;
        //[SerializeField]
        //private float _raySlopeLength;
        //[SerializeField]
        //private float _raySlopeOffset;

        private Quaternion _targetRotation;
        private bool _isRotating;

        [SerializeField, Min(0), Header("Speeds")]
        private float _airSpeedMultiplier;

        [field: SerializeField, Min(0)]
        public float GroundSpeed { get; private set; }
        public float Horizontal { get; private set; }
        public bool IsJumpInCooldown { get; private set; }

        public float AirSpeed => Speed * _airSpeedMultiplier;

        //private bool _canClimbSlope => SlopeAngle() <= _maxSlopeDegree;
        //private Vector3 _raySlopeOrigin => transform.position + (Vector3.up * _raySlopeOffset);

        private float _jumpForceScaled => _jumpForce /** transform.localScale.magnitude*/;
        private float _speedScaled => Speed / Rigidbody.mass;

        private void OnEnable()
        {
            //InputsManager.Inputs.PlayerMovement.Jump.started += Jump;
            InputsManager.Inputs.PlayerMovement.Movement.started += PerformMoving;
            InputsManager.Inputs.PlayerMovement.Movement.canceled += StopMoving;
            GameManager.Instance.EventManager.AddListener<float>(EventKeys.OnPlayerChangeSize, ChangeJumpForce);
        }

        private void OnDisable()
        {
            //InputsManager.Inputs.PlayerMovement.Jump.started -= Jump;
            InputsManager.Inputs.PlayerMovement.Movement.started -= PerformMoving;
            InputsManager.Inputs.PlayerMovement.Movement.canceled -= StopMoving;
            GameManager.Instance.EventManager.RemoveListener<float>(EventKeys.OnPlayerChangeSize, ChangeJumpForce);
        }

        private void FixedUpdate()
        {
            Move();
            Rotate();
        }

        public override void Move()
        {
            //if (!_canClimbSlope) return;
            //float effectiveSpeed = (_isSpeedAffectedByScale ? Speed * transform.lossyScale.magnitude : Speed) / Rigidbody.mass;
            Rigidbody.velocity = new Vector3(Rigidbody.velocity.x, Rigidbody.velocity.y, Horizontal * _speedScaled /*effectiveSpeed*/);
        }

        public override void Stop()
        {
            Horizontal = 0f;
        }

        public void Jump()
        {
            GameManager.Instance.EventManager.TriggerEvent(EventKeys.OnPlayerJump, transform.position);
            //float effectiveJumpForce = _isJumpAffectedByScale ? _jumpForce * transform.lossyScale.magnitude : _jumpForce;
            Rigidbody.velocity = Vector3.zero;
            Rigidbody.AddForce(transform.up * _jumpForceScaled, ForceMode.Impulse);
        }

        public void InvokeDisableJumpCooldown()
        {
            CancelInvoke("DisableJumpCooldown");
            Invoke("DisableJumpCooldown", _jumpCooldown);
        }

        public void EnableJumpCooldown()
        {
            IsJumpInCooldown = true;
        }

        private void DisableJumpCooldown()
        {
            IsJumpInCooldown = false;
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

        private void Rotate()
        {
            if (_isRotating)
                transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, _rotationSpeed);
        }

        private void CalculateTargetRotation(float direction)
        {
            _targetRotation = Quaternion.Euler(transform.eulerAngles.x, direction >= 0f ? 0f : 180f, transform.eulerAngles.z);
        }

        private void ChangeJumpForce(float force)
        {
            _jumpForce = force;
        }

        //private float SlopeAngle()
        //{
        //    if (Physics.Raycast(_raySlopeOrigin, -transform.up, out RaycastHit hit, _raySlopeLength, GroundLayers)
        //        && Physics.Raycast(_raySlopeOrigin, transform.forward, _raySlopeLength, GroundLayers))
        //    {
        //        return Vector3.Angle(hit.normal, transform.up);
        //    }

        //    return 0f;
        //}
    }
}