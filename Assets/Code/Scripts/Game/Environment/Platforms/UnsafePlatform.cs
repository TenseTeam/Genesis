namespace ProjectGenesis.Environment.Platforms
{
    using System.Collections;
    using UnityEngine;
    using VUDK.Generic.Serializable.Mathematics;
    using VUDK.Generic.Systems.EventsSystem;
    using ProjectGenesis.Constants.Events;

    public class UnsafePlatform : Platform
    {
        [SerializeField, Header("Platform")]
        private GameObject _platform;

        [SerializeField, Header("Time")]
        private Range<float> _time;

        private void OnEnable()
        {
            EventManager.AddListener(EventKeys.OnPlayerTakeDamage, () => SetEnablePlatform(true));
        }

        private void OnDisable()
        {
            EventManager.RemoveListener(EventKeys.OnPlayerTakeDamage, () => SetEnablePlatform(true));
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
