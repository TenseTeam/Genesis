namespace ProjectGenesis.Environment.DayNightCycleSystem
{
    using System.Collections;
    using UnityEngine;
    using VUDK.Generic.Managers;
    using ProjectGenesis.Constants.Events;

    public class DayNightMaterialReactor : MonoBehaviour
    {
        [SerializeField, Header("Material")]
        private Material _material;
        [SerializeField]
        private float _transitionDuration;

        [ColorUsageAttribute(true, true), SerializeField, Header("Day Material Color")]
        private Color _dayColor;
        [ColorUsageAttribute(true, true), SerializeField, Header("Night Material Color")]
        private Color _nightColor;

        private void OnEnable()
        {
            GameManager.Instance.EventManager.AddListener(EventKeys.OnBeginDay, () => ChangeEmissionColor(_dayColor));
            GameManager.Instance.EventManager.AddListener(EventKeys.OnBeginNight, () => ChangeEmissionColor(_nightColor));
        }

        private void OnDisable()
        {
            GameManager.Instance.EventManager.RemoveListener(EventKeys.OnBeginDay, () => ChangeEmissionColor(_dayColor));
            GameManager.Instance.EventManager.RemoveListener(EventKeys.OnBeginNight, () => ChangeEmissionColor(_nightColor));
        }

        private void ChangeEmissionColor(Color toColor)
        {
            StartCoroutine(MaterialChangeColorRoutine(toColor));
        }

        private IEnumerator MaterialChangeColorRoutine(Color toColor)
        {
            Color fromColor = _material.GetColor("_EmissionColor");

            float elapsedTime = 0f;
            while (elapsedTime < _transitionDuration)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / _transitionDuration);
                Color lerpedColor = Color.Lerp(fromColor, toColor, t);
                _material.SetColor("_EmissionColor", lerpedColor);
                yield return null;
            }

            _material.SetColor("_EmissionColor", toColor);
        }
    }
}
