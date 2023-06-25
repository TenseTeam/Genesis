using UnityEngine;
using VUDK.Extensions.Vectors;

namespace ProjectGenesis.Player
{
    public class PlayerStatus : MonoBehaviour
    {
        [SerializeField, Min(0.1f), Header("Resize")]
        private float _resizeSpeed;

        private Vector3 _originalSize;
        private Vector3 _targetSize;
        private bool _isResizing;

        public bool IsResized { get; private set; } = false;

        private void Awake()
        {
            _originalSize = transform.localScale;
        }

        private void Update()
        {
            Resize();
        }

        public void ApplyResize(Vector3 size)
        {
            _targetSize = IsResized ? _originalSize : size;
            _isResizing = true;
            IsResized = !IsResized;

            CancelInvoke("StopResizing");
            Invoke("StopResizing", 3f/_resizeSpeed);
        }

        private void Resize()
        {
            if (_isResizing)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, _targetSize, _resizeSpeed * Time.deltaTime);
                Debug.Log("Called");
            }
        }

        private void StopResizing()
        {
            _isResizing = false;
        }
    }
}
