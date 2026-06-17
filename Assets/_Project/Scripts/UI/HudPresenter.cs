using UnityEngine;
using TMPro;
using SpeedDrop.Gameplay;

namespace SpeedDrop.UI
{
    public sealed class HudPresenter : MonoBehaviour
    {
        [SerializeField] private ScoreCounter scoreCounter;
        [SerializeField] private SurvivalTimer survivalTimer;
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private string scoreFormat = "000000";
        [SerializeField] private string timerFormat = "000.00";

        private void Awake()
        {
            if (scoreCounter == null)
            {
                scoreCounter = FindFirstObjectByType<ScoreCounter>();
            }

            if (survivalTimer == null)
            {
                survivalTimer = FindFirstObjectByType<SurvivalTimer>();
            }

            if (scoreText == null)
            {
                scoreText = FindTextByName("ScoreText");
            }

            if (timerText == null)
            {
                timerText = FindTextByName("TimerText");
            }
        }

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
                scoreText.text = score.ToString(scoreFormat);
            }
        }

        private void UpdateTimer(float elapsedTime)
        {
            if (timerText != null)
            {
                timerText.text = elapsedTime.ToString(timerFormat);
            }
        }

        private static TMP_Text FindTextByName(string objectName)
        {
            TMP_Text[] texts = FindObjectsByType<TMP_Text>(FindObjectsSortMode.None);
            for (int i = 0; i < texts.Length; i++)
            {
                if (texts[i] != null && texts[i].name == objectName)
                {
                    return texts[i];
                }
            }

            return null;
        }
    }
}
