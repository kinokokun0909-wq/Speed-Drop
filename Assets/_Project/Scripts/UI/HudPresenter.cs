using UnityEngine;
using UnityEngine.UI;
using SpeedDrop.Gameplay;

namespace SpeedDrop.UI
{
    public sealed class HudPresenter : MonoBehaviour
    {
        [SerializeField] private ScoreCounter scoreCounter;
        [SerializeField] private SurvivalTimer survivalTimer;
        [SerializeField] private Text scoreText;
        [SerializeField] private Text timerText;

        private void OnEnable()
        {
            if (scoreCounter != null)
            {
                scoreCounter.ScoreChanged += UpdateScore;
                UpdateScore(scoreCounter.Score);
            }

            if (survivalTimer != null)
            {
                survivalTimer.TimeChanged += UpdateTimer;
                UpdateTimer(survivalTimer.ElapsedTime);
            }
        }

        private void OnDisable()
        {
            if (scoreCounter != null)
            {
                scoreCounter.ScoreChanged -= UpdateScore;
            }

            if (survivalTimer != null)
            {
                survivalTimer.TimeChanged -= UpdateTimer;
            }
        }

        private void UpdateScore(int score)
        {
            if (scoreText != null)
            {
                scoreText.text = score.ToString("000000");
            }
        }

        private void UpdateTimer(float elapsedTime)
        {
            if (timerText != null)
            {
                timerText.text = elapsedTime.ToString("000.00");
            }
        }
    }
}
