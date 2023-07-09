namespace ProjectGenesis.Managers
{
    using UnityEngine;
    using VUDK.Generic.Systems.EventsSystem;
    using ProjectGenesis.Constants.Events;
    using VUDK.Generic.Managers;

    public class GameoverManager : MonoBehaviour
    {
        private void OnEnable()
        {
            GameManager.Instance.EventManager.AddListener(EventKeys.OnGameover, Gameover);
        }

        private void OnDisable()
        {
            GameManager.Instance.EventManager.RemoveListener(EventKeys.OnGameover, Gameover);
        }

        private void Gameover()
        {
            Debug.Log("Gameover!");
        }
    }
}