namespace ProjectGenesis.Environment.Platforms
{
    using System.Collections;
    using UnityEngine;
    using VUDK.Generic.Serializable.Mathematics;
    using VUDK.Generic.Systems.EventsSystem;
    using ProjectGenesis.Constants.Events;
    using VUDK.Generic.Managers;

    public class UnsafePlatform : Platform
    {
        [SerializeField, Header("Platform")]
        private GameObject _platform;

        [SerializeField, Header("Time")]
        private Range<float> _time;

        private void OnEnable()
        {
            GameManager.Instance.EventManager.AddListener(EventKeys.OnPlayerTakeDamage, () => SetEnablePlatform(true));
        }

        private void OnDisable()
        {
            GameManager.Instance.EventManager.RemoveListener(EventKeys.OnPlayerTakeDamage, () => SetEnablePlatform(true));
        }

        protected override void OnEntityEnterPlatform(Collision entityCollision)
        {
            base.OnEntityEnterPlatform(entityCollision);
            StartCoroutine(WaitBeforeDisablePlatform());
        }

        private IEnumerator WaitBeforeDisablePlatform()
        {
            yield return new WaitForSeconds(_time.Random());
            SetEnablePlatform(false);
        }

        private void SetEnablePlatform(bool enabled)
        {
            _platform.SetActive(enabled);
        }
    }
}
