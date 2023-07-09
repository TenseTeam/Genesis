namespace VUDK.Generic.Features.Score
{
    using UnityEngine;
    using VUDK.Generic.Managers;
    using VUDK.Generic.Systems.EventsSystem;
    using VUDK.Generic.Systems.EventsSystem.Events;

    public class Score : MonoBehaviour
    {
        [SerializeField]
        private string _scorePref;

        public int ScoreValue { get; private set; }
        public int HighScore => PlayerPrefs.GetInt(_scorePref);

        private void Start()
        {
            GameManager.Instance.EventManager.TriggerEvent(EventKeys.ScoreEvents.OnScoreChange, ScoreValue);
            GameManager.Instance.EventManager.TriggerEvent(EventKeys.ScoreEvents.OnHighScoreChange, HighScore);
        }

        public void ChangeScore(int scoreToAdd)
        {
            ScoreValue += scoreToAdd;

            if(ScoreValue < 0)
                ScoreValue = 0;

            SaveHighScore();
        }

        private void SaveHighScore()
        {
            if (ScoreValue > HighScore)
            {
                PlayerPrefs.SetInt(_scorePref, ScoreValue);
                GameManager.Instance.EventManager.TriggerEvent(EventKeys.ScoreEvents.OnHighScoreChange, HighScore);
            }
        }
    }
}

