namespace ProjectGenesis.Environment.Platforms
{
    using System.Collections;
    using UnityEngine;
    using VUDK.Generic.Serializable.Mathematics;

    public class UnsafePlatform : Platform
    {
        [SerializeField, Header("Time")]
        private Range<float> _time;

        protected override void OnEntityEnterPlatform(Collision entityCollision)
        {
            base.OnEntityEnterPlatform(entityCollision);
            StartCoroutine(WaitBeforeDisablePlatform());
        }

        private IEnumerator WaitBeforeDisablePlatform()
        {
            yield return new WaitForSeconds(_time.Random());
            gameObject.SetActive(false);
        }
    }
}
