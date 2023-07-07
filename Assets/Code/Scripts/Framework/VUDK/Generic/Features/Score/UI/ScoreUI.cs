namespace VUDK.Generic.Features.Score.UI
{
    using UnityEngine;
    using TMPro;
    using VUDK.Generic.Systems.EventsSystem;
    using VUDK.Generic.Systems.EventsSystem.Events;

    public class ScoreUI : MonoBehaviour
    {
        [SerializeField, Header("Incipits")]
        private string _incipitScore;
        [SerializeField]
        private string _incipitHighScore;

        [SerializeField, Header("Texts")]
        private TMP_Text _scoreText;
        [SerializeField]
        private TMP_Text _highscoreText;

        private void OnEnable()
        {
            EventManager.AddListener<int>(EventKeys.ScoreEvents.OnScoreChange, UpdateScoreText);
            EventManager.AddListener<int>(EventKeys.ScoreEvents.OnHighScoreChange, UpdateHighScoreText);
        }

        private void OnDisable()
        {
            EventManager.RemoveListener<int>(EventKeys.ScoreEvents.OnScoreChange, UpdateScoreText);
            EventManager.RemoveListener<int>(EventKeys.ScoreEvents.OnHighScoreChange, UpdateHighScoreText);
        }

        private void UpdateScoreText(int score)
        {
            _scoreText.text = _incipitScore + score.ToString();
        }

        private void UpdateHighScoreText(int highScore)
        {
            _highscoreText.text = _incipitHighScore + highScore.ToString();
        }
    }
}