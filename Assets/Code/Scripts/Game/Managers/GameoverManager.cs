namespace ProjectGenesis.Managers
{
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using VUDK.Generic.Managers;
    using ProjectGenesis.Constants.Events;

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
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}