using UnityEngine;
using VUDK.Extensions.Transform;
using VUDK.Extensions.Vectors;

namespace ProjectGenesis.Player
{
    public class PlayerStatus : MonoBehaviour
    {
        [SerializeField, Min(0.1f), Header("Resize")]
        private float _resizeSpeed;
        [SerializeField, Min(0f)]
        private float _resizeTime;

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
    }
}
