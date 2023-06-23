namespace VUDK.Generic.Features.Camera
{
    using UnityEngine;

    public class SimpleCameraFollow : MonoBehaviour
    {
        [SerializeField, Header("Camera")]
        private float _speed;
        [SerializeField]
        private Vector3 _cameraOffset;

        [SerializeField, Header("Target")]
        private Transform _target;

        private void Update()
        {
            FollowTarget();
        }

        private void FollowTarget()
        {
            Vector3 desiredPosition = _target.position + _cameraOffset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, _speed * Time.deltaTime);
        }
    }
}