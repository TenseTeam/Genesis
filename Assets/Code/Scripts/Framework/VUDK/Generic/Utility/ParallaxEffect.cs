namespace VUDK.Generic.Utility
{
    using UnityEngine;

    [RequireComponent(typeof(SpriteRenderer))]
    public class ParralaxEffect : MonoBehaviour
    {
        [SerializeField]
        public Camera _camera;
        [SerializeField]
        public float _parallaxValue;

        private float _length;
        private float _xOrignalPosition;
        private float _yOriginalPosition;

        private void Awake()
        {
            TryGetComponent(out SpriteRenderer sprite);
            _length = sprite.bounds.size.x;
        }

        private void Start()
        {
            _xOrignalPosition = transform.position.x;
            _yOriginalPosition = transform.position.y;
        }

        private void Update()
        {
            float temp = (_camera.transform.position.x * (1 - _parallaxValue));
            float dist = (_camera.transform.position.x * _parallaxValue);
            float ydist = (_camera.transform.position.y * _parallaxValue);

            transform.position = new Vector3(_xOrignalPosition + dist, _yOriginalPosition + ydist, transform.position.z);

            if (temp > _xOrignalPosition + _length)
                _xOrignalPosition += _length;
            else if (temp < _xOrignalPosition - _length)
                _xOrignalPosition -= _length;
        }
    }
}