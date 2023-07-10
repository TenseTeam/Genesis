namespace ProjectGenesis.UI.Vocals
{
    using UnityEngine;
    using UnityEngine.UI;
    using VUDK.Generic.Managers;
    using ProjectGenesis.Constants.Events;
    using System.Collections;

    public class Vocal : MonoBehaviour
    {
        [SerializeField, Header("Vocal Clip")]
        private AudioClip _vocal;

        [SerializeField, Header("Fill")]
        private Image _vocalFill;

        private void Awake()
        {
            _vocalFill.fillAmount = 0f;
        }

        public void PlayVocal()
        {
            GameManager.Instance.EventManager.TriggerEvent(EventKeys.OnEnterTriggerVocal, _vocal);
            StartCoroutine(FillVocalRoutine());
        }

        public void StopVocal()
        {
            GameManager.Instance.EventManager.TriggerEvent(EventKeys.OnExitTriggerVocal);
            StopAllCoroutines();
            _vocalFill.fillAmount = 0f;
        }

        private IEnumerator FillVocalRoutine()
        {
            float time = 0f;

            while (time < _vocal.length)
            {
                time += Time.deltaTime;
                _vocalFill.fillAmount = time / _vocal.length;
                yield return null;
            }
        }
    }
}
