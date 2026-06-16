using UnityEngine;
using SpeedDrop.Gameplay;

namespace SpeedDrop.GameModes
{
    public sealed class EndlessDropMode : MonoBehaviour, IGameMode
    {
        [SerializeField] private ScoreCounter scoreCounter;
        [SerializeField] private float scorePerSecond = 10f;

        private bool running;
        private float scoreBuffer;

        public void Begin()
        {
            running = true;
            scoreBuffer = 0f;
            scoreCounter?.ResetScore();
        }

        public void Tick(float deltaTime)
        {
            if (!running || scoreCounter == null)
            {
                return;
            }

            scoreBuffer += scorePerSecond * deltaTime;
            int wholeScore = Mathf.FloorToInt(scoreBuffer);
            if (wholeScore <= 0)
            {
                return;
            }

            scoreBuffer -= wholeScore;
            scoreCounter.AddScore(wholeScore);
        }

        public void End()
        {
            running = false;
        }

        private void Update()
        {
            Tick(Time.deltaTime);
        }
    }
}
