namespace VUDK.Generic.Features.Timer
{
    using System.Collections;
    using UnityEngine;
    using VUDK.Generic.Managers;
    using VUDK.Generic.Systems.EventsSystem;
    using VUDK.Generic.Systems.EventsSystem.Events;

    public class CountdownTimer : MonoBehaviour
    {
        public void StartTimer(int time)
        {
            StartCoroutine(CountdownRoutine(time));
        }

        public void StopTimer()
        {
            StopAllCoroutines();
        }

        private IEnumerator CountdownRoutine(int time)
        {
            do
            {
                GameManager.Instance.EventManager.TriggerEvent(EventKeys.CountdownEvents.OnCountdownCount, time);
                yield return new WaitForSeconds(1);
                time--;
            } while (time > 0);

            GameManager.Instance.EventManager.TriggerEvent(EventKeys.CountdownEvents.OnCountdownCount, time);
            GameManager.Instance.EventManager.TriggerEvent(EventKeys.CountdownEvents.OnCountdownTimesUp);
        }
    }
}
