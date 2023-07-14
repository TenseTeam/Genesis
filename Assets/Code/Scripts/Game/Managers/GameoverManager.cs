namespace ProjectGenesis.Managers
{
    using UnityEngine;
    using VUDK.Generic.Managers;
    using VUDK.Generic.Systems.EntitySystem;
    using EventKeysVUDK = VUDK.Generic.Systems.EventsSystem.Events.EventKeys;
    using ProjectGenesis.Constants.Events;
    using UnityEngine.SceneManagement;

    public class GameoverManager : MonoBehaviour
    {
        [SerializeField, Header("Gameover Scene")]
        private int _sceneToLoadOnGameover;

        private void OnEnable()
        {
            GameManager.Instance.EventManager.AddListener<EntityBase>(EventKeysVUDK.EntityEvents.OnEntityDeath, Gameover);
        }

        private void OnDisable()
        {
            GameManager.Instance.EventManager.AddListener<EntityBase>(EventKeysVUDK.EntityEvents.OnEntityDeath, Gameover);
        }

        private void Gameover(EntityBase entity)
        {
            SceneManager.LoadScene(_sceneToLoadOnGameover, LoadSceneMode.Single);
        }
    }
}