namespace ProjectGenesis.UI.Player
{
    using UnityEngine.UI;
    using UnityEngine;
    using VUDK.Generic.Systems.EventsSystem;
    using ProjectGenesis.Constants.Events;
    using System.Collections.Generic;

    public class UIPlayer : MonoBehaviour
    {
        [SerializeField, Header("Hearts")]
        private GridLayoutGroup _heartGrid;
        [SerializeField]
        private GameObject _heartPrefab;

        private List<GameObject> _hearts = new List<GameObject>();

        private void OnEnable()
        {
            EventManager.AddListener<int, int>(EventKeys.OnHitPointsPlayerSetup, SetupHealth);
            EventManager.AddListener(EventKeys.OnPlayerTakeDamage, RemoveHeart);
        }

        private void OnDisable()
        {
            EventManager.RemoveListener<int, int>(EventKeys.OnHitPointsPlayerSetup, SetupHealth);
            EventManager.RemoveListener(EventKeys.OnPlayerTakeDamage, RemoveHeart);
        }

        private void SetupHealth(int current, int max)
        {
            for (int i = 0; i < max; i++)
            {
                GameObject heartGO = Instantiate(_heartPrefab, _heartGrid.transform.position, _heartGrid.transform.rotation, _heartGrid.transform); // No needs for a factory now.
                _hearts.Add(heartGO);
            }
        }

        private void RemoveHeart()
        {
            if (_hearts.Count == 0) return;

            GameObject toRemove = _hearts[_hearts.Count-1];
            _hearts.Remove(toRemove);
            Destroy(toRemove);
        }
    }
}
