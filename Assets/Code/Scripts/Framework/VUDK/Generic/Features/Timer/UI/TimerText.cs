namespace VUDK.Generic.Features.Timer.UI
{
    using UnityEngine;
    using TMPro;
    using VUDK.Generic.Systems.EventsSystem.Events;
    using VUDK.Generic.Systems.EventsSystem;

    public class TimerText : MonoBehaviour
    {
        [SerializeField]
        private string _incipit;

        [SerializeField]
        private TMP_Text _text;

        private void OnEnable()
        {
            EventManager.AddListener<int>(EventKeys.CountdownEvents.OnCountdownCount, UpdateTimerText);
        }

        private void OnDisable()
        {
            EventManager.RemoveListener<int>(EventKeys.CountdownEvents.OnCountdownCount, UpdateTimerText);
        }

        private void UpdateTimerText(int time)
        {
            _text.text = _incipit + time.ToString();
        }
    }
}