using UnityEngine;
using UnityEngine.UI;
using SpeedDrop.Gameplay;

namespace SpeedDrop.UI
{
    public sealed class HudPresenter : MonoBehaviour
    {
        [SerializeField] private ScoreCounter scoreCounter;
        [SerializeField] private Text scoreText;

        private void OnEnable()
        {
            if (scoreCounter != null)
            {
                scoreCounter.ScoreChanged += UpdateScore;
                UpdateScore(scoreCounter.Score);
            }
        }

        private void OnDisable()
        {
            if (scoreCounter != null)
            {
                scoreCounter.ScoreChanged -= UpdateScore;
            }
        }

        private void UpdateScore(int score)
        {
            if (scoreText != null)
            {
                scoreText.text = score.ToString("000000");
            }
        }
    }
}
