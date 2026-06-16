using System;
using UnityEngine;

namespace SpeedDrop.Gameplay
{
    public sealed class ScoreCounter : MonoBehaviour
    {
        public event Action<int> ScoreChanged;

        [SerializeField] private int score;

        public int Score => score;

        public void ResetScore()
        {
            score = 0;
            ScoreChanged?.Invoke(score);
        }

        public void AddScore(int amount)
        {
            if (amount <= 0)
            {
                return;
            }

            score += amount;
            ScoreChanged?.Invoke(score);
        }
    }
}
