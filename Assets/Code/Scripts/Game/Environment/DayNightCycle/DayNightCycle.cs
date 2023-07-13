namespace ProjectGenesis.Environment.DayNightCycleSystem
{
    using System.Collections;
    using UnityEngine;
    using VUDK.Generic.Managers;
    using ProjectGenesis.Constants.Events;
    using VUDK.Generic.Serializable;

    public class DayNightCycle : MonoBehaviour
    {
        [SerializeField, Header("Camera")]
        private Camera _camera;

        [SerializeField, Header("Backfround Color")]
        private Color _nightColor = Color.black;
        [SerializeField]
        private Color _dayColor = Color.blue;
        [SerializeField, Min(0f)]
        private float _durationTransitionBackground;

        [SerializeField, Header("Light")]
        private Light _light;
        [SerializeField]
        private float _dayIntensity;
        [SerializeField]
        private float _nightIntensity;
        [SerializeField]
        private Color _dayLightColor;
        [SerializeField]
        private Color _nightLightColor;
        [SerializeField]
        private float _durationTransitionLight;

        [SerializeField, Header("Target Follow")]
        private Transform _lockOnTarget;
        [SerializeField]
        private XYZBools _followOnAxis;
        [SerializeField]
        private Vector3 _offset;
        [SerializeField, Min(0f)]
        private float _followSpeed;

        [SerializeField, Header("Setting")]
        private bool _startAsDay;

        private Vector3 _lockOnPosition =>
            new Vector3(
                _followOnAxis.X ? _lockOnTarget.position.x + _offset.x: transform.position.x,
                _followOnAxis.Y ? _lockOnTarget.position.y + _offset.y : transform.position.y,
                _followOnAxis.Z ? _lockOnTarget.position.z + _offset.z : transform.position.z
                );

        private void Start()
        {
            if (_startAsDay)
            {
                GameManager.Instance.EventManager.TriggerEvent(EventKeys.OnBeginDay);
                SetToDay();
            }
            else
            {
                GameManager.Instance.EventManager.TriggerEvent(EventKeys.OnBeginNight);
                SetToNight();
            }
        }

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, _lockOnPosition, _followSpeed * Time.deltaTime);
        }

        public void TransitionToDay()
        {
            GameManager.Instance.EventManager.TriggerEvent(EventKeys.OnBeginDay);
            StartCoroutine(BackgroundCycleRoutine(_dayColor));
            StartCoroutine(LightCycleRoutine(_dayLightColor, _dayIntensity));
        }

        public void TransitionToNight()
        {
            GameManager.Instance.EventManager.TriggerEvent(EventKeys.OnBeginNight);
            StartCoroutine(BackgroundCycleRoutine(_nightColor));
            StartCoroutine(LightCycleRoutine(_nightLightColor, _nightIntensity));
        }

        private void SetToDay()
        {
            _camera.backgroundColor = _dayColor;
            _light.color = _dayLightColor;
            _light.intensity = _dayIntensity;
        }

        private void SetToNight()
        {
            _camera.backgroundColor = _nightColor;
            _light.color = _nightLightColor;
            _light.intensity = _nightIntensity;
        }

        private IEnumerator BackgroundCycleRoutine(Color toColor)
        {
            Color fromColor = _camera.backgroundColor;

            float elapsedTime = 0f;
            while (elapsedTime < _durationTransitionBackground)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / _durationTransitionBackground);
                Color lerpedColor = Color.Lerp(fromColor, toColor, t);
                _camera.backgroundColor = lerpedColor;
                yield return null;
            }

            _camera.backgroundColor = toColor;
        }

        private IEnumerator LightCycleRoutine(Color toColor, float toIntensity)
        {
            Color fromColor = _light.color;
            float fromIntensity = _light.intensity;

            float elapsedTime = 0f;
            while (elapsedTime < _durationTransitionLight)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / _durationTransitionBackground);

                _light.color = Color.Lerp(fromColor, toColor, t);
                _light.intensity = Mathf.Lerp(fromIntensity, toIntensity, t);
                yield return null;
            }

            _light.color = toColor;
            _light.intensity = toIntensity;
        }
    }
}
