namespace ProjectGenesis.Environment.Platforms
{
    using System.Collections;
    using UnityEngine;
    using VUDK.Generic.Managers;
    using VUDK.Generic.Serializable;
    using VUDK.Generic.Systems.EventsSystem.Events;
    using VUDK.Generic.Systems.EntitySystem;

    public class UnsafePlatform : Platform
    {
        [SerializeField, Header("Platform")]
        private GameObject _platform;

        [SerializeField, Header("Time")]
        private Range<float> _time;

        private void OnEnable()
        {
            GameManager.Instance.EventManager.AddListener<EntityBase>(EventKeys.EntityEvents.OnEntityTakeDamage, (ent) => ReEnablePlatform());
        }

        private void OnDisable()
        {
            GameManager.Instance.EventManager.RemoveListener<EntityBase>(EventKeys.EntityEvents.OnEntityTakeDamage, (ent) => ReEnablePlatform());
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

        private void ReEnablePlatform()
        {
            StopAllCoroutines();
            SetEnablePlatform(true);
        }
    }
}
