namespace VUDK.Generic.Utility
{
    using UnityEngine;
    using UnityEngine.ProBuilder.Shapes;

    [RequireComponent(typeof(SpriteRenderer))]
    public class ParralaxEffect : MonoBehaviour
    {
        [SerializeField]
        public GameObject _anchor;
        [SerializeField]
        public float _parallaxValue;

        private float _length;
        private float _zOrignalPosition;
        private float _yOriginalPosition;

        private SpriteRenderer _sprite;

        private void Awake()
        {
            TryGetComponent(out _sprite);
            _length = _sprite.bounds.size.z;
        }

        private void Start()
        {
            _zOrignalPosition = transform.position.z;
            _yOriginalPosition = transform.position.y;
        }

        private void Update()
        {
            float temp = (_anchor.transform.position.z * (1 - _parallaxValue));
            float dist = (_anchor.transform.position.z * _parallaxValue);
            float ydist = (_anchor.transform.position.y * _parallaxValue);

            transform.position = new Vector3(transform.position.x, _yOriginalPosition + ydist, _zOrignalPosition + dist);

            if (temp > _zOrignalPosition + _length)
                _zOrignalPosition += _length;
            else if (temp < _zOrignalPosition - _length)
                _zOrignalPosition -= _length;
        }
    }
}