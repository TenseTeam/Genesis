namespace ProjectGenesis.Environment.DayNightCycleSystem
{
    using ProjectGenesis.Constants.Events;
    using UnityEngine;
    using VUDK.Generic.Managers;

    public class DayNightLevelParticles : MonoBehaviour
    {
        [SerializeField, Header("Night and Day Particles")]
        private ParticleSystem _dayParticles;
        [SerializeField]
        private ParticleSystem _nightParticles;

        private ParticleSystem _currentParticles;

        private void OnEnable()
        {
            GameManager.Instance.EventManager.AddListener(EventKeys.OnBeginDay, () => SetParticles(_dayParticles));
            GameManager.Instance.EventManager.AddListener(EventKeys.OnBeginNight, () => SetParticles(_nightParticles));
        }

        private void OnDisable()
        {
            GameManager.Instance.EventManager.RemoveListener(EventKeys.OnBeginDay, () => SetParticles(_dayParticles));
            GameManager.Instance.EventManager.RemoveListener(EventKeys.OnBeginNight, () => SetParticles(_nightParticles));
        }

        public void Play()
        {
            _currentParticles.Play();
        }

        private void SetParticles(ParticleSystem particles)
        {
            _currentParticles = particles;
        }
    }
}
