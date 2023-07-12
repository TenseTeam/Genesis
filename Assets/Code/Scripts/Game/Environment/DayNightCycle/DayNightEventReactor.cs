namespace ProjectGenesis.Environment.DayNightCycleSystem
{
    using UnityEngine;
    using UnityEngine.Events;
    using VUDK.Generic.Managers;
    using ProjectGenesis.Constants.Events;

    public class DayNightEventReactor : MonoBehaviour
    {
        public UnityEvent OnBeginDay;
        public UnityEvent OnBeginNight;

        private void OnEnable()
        {
            GameManager.Instance.EventManager.AddListener(EventKeys.OnBeginDay, () => OnBeginDay?.Invoke());
            GameManager.Instance.EventManager.AddListener(EventKeys.OnBeginNight, () => OnBeginNight?.Invoke());
        }

        private void OnDisable()
        {
            GameManager.Instance.EventManager.RemoveListener(EventKeys.OnBeginDay, () => OnBeginDay?.Invoke());
            GameManager.Instance.EventManager.RemoveListener(EventKeys.OnBeginNight, () => OnBeginNight?.Invoke());
        }
    }
}