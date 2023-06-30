namespace ProjectGenesis.Environment.Traps
{
    using System.Collections;
    using UnityEngine;
    using VUDK.Generic.Serializable.Mathematics;

    public class TimedTrap : MonoBehaviour
    {
        [SerializeField, Header("Trap")]
        private Trap _trap;

        [SerializeField, Header("Cooldown")]
        private Range<float> _cooldown;

        private void Start()
        {
            StartCoroutine(TrapRoutine(true));
        }

        public void Stop()
        {
            StopAllCoroutines();
        }

        private IEnumerator TrapRoutine(bool enabled)
        {
            _trap.gameObject.SetActive(enabled);
            yield return new WaitForSeconds(_cooldown.Random());
            StartCoroutine(TrapRoutine(!enabled));
        }
    }
}