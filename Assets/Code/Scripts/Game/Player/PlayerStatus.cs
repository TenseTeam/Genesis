namespace ProjectGenesis.Player
{
    using ProjectGenesis.Constants.Events;
    using System;
    using UnityEngine;
    using VUDK.Extensions.Transform;
    using VUDK.Generic.Managers;
    using VUDK.Generic.Systems.EventsSystem;

    public class PlayerStatus : MonoBehaviour, ICloneable
    {
        [SerializeField, Min(0.1f), Header("Resize")]
        private float _resizeSpeed;
        [SerializeField, Min(0f)]
        private float _resizeTime;

        [SerializeField, Min(0f), Header("Jump Change")]
        private float _resizedJumpforce;
        [SerializeField]
        private float _normalJumpForce;

        private Vector3 _originalSize;
        private Vector3 _targetSize;
        private bool _isResizing;

        public bool IsResized { get; private set; }
        public bool IsSplitted { get; private set; }

        private void Awake()
        {
            _originalSize = transform.localScale;
        }

        private void Update()
        {
            Resize();
        }

        public void ToggleResize(Vector3 size)
        {
            _targetSize = IsResized ? _originalSize : size;
            _isResizing = true;
            IsResized = !IsResized;

            if (_targetSize.magnitude >= _originalSize.magnitude)
            {
                GameManager.Instance.EventManager.TriggerEvent(EventKeys.OnPlayerSizeUp);
                GameManager.Instance.EventManager.TriggerEvent(EventKeys.OnPlayerChangeSize, _normalJumpForce);
            }
            else
            {
                GameManager.Instance.EventManager.TriggerEvent(EventKeys.OnPlayerSizeDown);
                GameManager.Instance.EventManager.TriggerEvent(EventKeys.OnPlayerChangeSize, _resizedJumpforce);
            }

            CancelInvoke("StopResizing");
            Invoke("StopResizing", _resizeTime);
        }

        public void RemoveResize()
        {
            CancelInvoke("StopResizing");
            StopResizing();
            _targetSize = _originalSize;
            IsResized = false;
            transform.SetLossyScale(_targetSize);
        }

        public void ApplySplit()
        {
            IsSplitted = true;
        }

        public void RemoveSplit()
        {
            IsSplitted = false;
        }

        public void Clear()
        {
            CancelInvoke();
            RemoveSplit();
            RemoveResize();
        }

        private void Resize()
        {
            if (_isResizing)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, _targetSize, _resizeSpeed * Time.deltaTime);
            }
        }

        private void StopResizing()
        {
            _isResizing = false;
        }

        public object Clone()
        {
            PlayerStatus clonedStatus = (PlayerStatus)MemberwiseClone();
            clonedStatus._originalSize = _originalSize;
            clonedStatus._targetSize = _targetSize;
            clonedStatus._isResizing = _isResizing;
            clonedStatus.IsResized = IsResized;
            clonedStatus.IsSplitted = IsSplitted;

            return clonedStatus;
        }
    }
}
