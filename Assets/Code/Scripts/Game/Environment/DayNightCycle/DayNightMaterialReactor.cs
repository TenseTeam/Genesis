namespace ProjectGenesis.Environment.DayNightCycleSystem
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Experimental.GlobalIllumination;
    using UnityEngine.Rendering;
    using VUDK.Generic.Managers;
    using ProjectGenesis.Constants.Events;

    public class DayNightMaterialReactor : MonoBehaviour
    {
        [SerializeField, Header("Material")]
        private Material _material;
        [SerializeField]
        private float _transitionDuration;

        [ColorUsageAttribute(true, true), SerializeField, Header("Emission Color")]
        private Color _color;

        private Color _originalColor;

        private void Awake()
        {
            _originalColor = _material.GetColor("_EmissionColor");
        }

        private void OnEnable()
        {
        //    GameManager.Instance.EventManager.AddListener(EventKeys.OnBeginNight, () => ChangeEmissionColor(_color, _intensity));
        //    GameManager.Instance.EventManager.AddListener(EventKeys.OnBeginDay, () => ChangeEmissionColor(_originalColor, _originalIntensity));
        }

        private void OnDisable()
        {
        //    GameManager.Instance.EventManager.RemoveListener(EventKeys.OnBeginNight, () => ChangeEmissionColor(_color, _intensity));
        //    GameManager.Instance.EventManager.RemoveListener(EventKeys.OnBeginDay, () => ChangeEmissionColor(_originalColor, _originalIntensity));
        }

        private void ChangeEmissionColor(Color toColor, float toIntensity)
        {
            StartCoroutine(MaterialChangeColorRoutine(toColor, toIntensity));
        }

        private IEnumerator MaterialChangeColorRoutine(Color toColor, float toIntensity)
        {
            Color fromColor = _material.GetColor("_EmissionColor");
            float fromIntensity = _material.GetFloat("_EmissionMultiplier");

            float elapsedTime = 0f;
            while (elapsedTime < _transitionDuration)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / _transitionDuration);
                Color lerpedColor = Color.Lerp(fromColor, toColor, t);
                float lerpedIntensity = Mathf.Lerp(fromIntensity, toIntensity, t);
                _material.SetColor("_EmissionColor", lerpedColor);
                _material.SetFloat("_EmissionMultiplier", lerpedIntensity);
                yield return null;
            }

            _material.SetColor("_EmissionColor", toColor);
            _material.SetFloat("_EmissionMultiplier", toIntensity);
        }
    }
}
