namespace ProjectGenesis.Environment.DayNightCycleSystem
{
    using ProjectGenesis.Constants.Events;
    using System.Collections;
    using UnityEngine;
    using VUDK.Generic.Systems.EventsSystem;

    public class LightReactor : MonoBehaviour
    {
        [SerializeField, Header("Light")]
        private Light _light;
        [SerializeField, Min(0)]
        private float _lightIntensityOn;
        [SerializeField, Min(0)]
        private float _lightIntensityOff;
        [SerializeField, Min(0)]
        private float _transitionDuration;

        private void OnEnable()
        {
            EventManager.AddListener(EventKeys.OnBeginDay, () => TransitionTo(_lightIntensityOff));
            EventManager.AddListener(EventKeys.OnBeginNight, () => TransitionTo(_lightIntensityOn));
        }

        private void OnDisable()
        {
            EventManager.RemoveListener(EventKeys.OnBeginDay, () => TransitionTo(_lightIntensityOff));
            EventManager.RemoveListener(EventKeys.OnBeginNight, () => TransitionTo(_lightIntensityOn));
        }

        private void TransitionTo(float toIntensity)
        {
            StartCoroutine(SwitchLightRoutine(toIntensity));
        }

        private IEnumerator SwitchLightRoutine(float toIntensity)
        {
            float fromIntensity = _light.intensity;

            float elapsedTime = 0f;
            while (elapsedTime < _transitionDuration)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / _transitionDuration);

                _light.intensity = Mathf.Lerp(fromIntensity, toIntensity, t);
                yield return null;
            }

            _light.intensity = toIntensity;

            //if(_light.intensity <= 0.05f)
            //    _light.enabled = false;
            //else
            //    _light.enabled = true;
        }
    }
}