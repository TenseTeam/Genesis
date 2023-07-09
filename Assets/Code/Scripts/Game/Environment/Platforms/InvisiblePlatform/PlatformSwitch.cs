namespace ProjectGenesis.Environment.Platforms
{
    using UnityEngine;
    using VUDK.Generic.Systems.TriggerSystem;

    public class PlatformSwitch : TriggerEvent
    {
        [SerializeField]
        private Platform _platform;

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            _platform.gameObject.SetActive(true);
        }
    }
}