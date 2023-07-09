namespace ProjectGenesis.Managers
{
    using UnityEngine;
    using VUDK.Generic.Systems.EventsSystem;
    using ProjectGenesis.Constants.Events;

    public class GameoverManager : MonoBehaviour
    {
        private void OnEnable()
        {
            EventManager.AddListener(EventKeys.OnGameover, Gameover);
        }

        private void OnDisable()
        {
            EventManager.RemoveListener(EventKeys.OnGameover, Gameover);
        }

        private void Gameover()
        {
            Debug.Log("Gameover!");
        }
    }
}