namespace ProjectGenesis.UI.Player
{
    using System.Collections.Generic;
    using UnityEngine.UI;
    using UnityEngine;
    using VUDK.Generic.Managers;
    using VUDK.Generic.Systems.EntitySystem;
    using VUDK.Generic.Systems.EventsSystem.Events;

    public class UIPlayer : MonoBehaviour
    {
        [SerializeField, Header("Hearts")]
        private GridLayoutGroup _heartGrid;
        [SerializeField]
        private GameObject _heartPrefab;

        private List<GameObject> _hearts = new List<GameObject>();

        private void OnEnable()
        {
            GameManager.Instance.EventManager.AddListener<EntityBase>(EventKeys.EntityEvents.OnEntityInit, (ent) => SetupHealth((int)ent.StartingHitPoints));
            GameManager.Instance.EventManager.AddListener<EntityBase>(EventKeys.EntityEvents.OnEntityTakeDamage, (ent) => RemoveHeart());
        }

        private void OnDisable()
        {
            GameManager.Instance.EventManager.RemoveListener<EntityBase>(EventKeys.EntityEvents.OnEntityInit, (ent) => SetupHealth((int)ent.StartingHitPoints));
            GameManager.Instance.EventManager.RemoveListener<EntityBase>(EventKeys.EntityEvents.OnEntityTakeDamage, (ent) => RemoveHeart());
        }

        private void SetupHealth(int max)
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
