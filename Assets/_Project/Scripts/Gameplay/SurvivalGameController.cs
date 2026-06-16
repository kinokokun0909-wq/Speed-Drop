using UnityEngine;
using SpeedDrop.Player;
using SpeedDrop.Stage;

namespace SpeedDrop.Gameplay
{
    public sealed class SurvivalGameController : MonoBehaviour
    {
        [SerializeField] private GameStateController gameStateController;
        [SerializeField] private SurvivalTimer survivalTimer;
        [SerializeField] private ScoreCounter scoreCounter;
        [SerializeField] private PlayerCollisionHandler playerCollisionHandler;
        [SerializeField] private StageScroller[] stageScrollers;
        [SerializeField] private bool startOnStart = true;
        [SerializeField] private bool obstacleHitEndsRun = true;
        [SerializeField] private int goalScoreBonus = 1000;

        private bool runActive;

        private void Awake()
        {
            if (gameStateController == null)
            {
                gameStateController = FindFirstObjectByType<GameStateController>();
            }

            if (survivalTimer == null)
            {
                survivalTimer = FindFirstObjectByType<SurvivalTimer>();
            }

            if (scoreCounter == null)
            {
                scoreCounter = FindFirstObjectByType<ScoreCounter>();
            }

            if (playerCollisionHandler == null)
            {
                playerCollisionHandler = FindFirstObjectByType<PlayerCollisionHandler>();
            }

            if (stageScrollers == null || stageScrollers.Length == 0)
            {
                stageScrollers = FindObjectsByType<StageScroller>(FindObjectsSortMode.None);
            }
        }

        private void OnEnable()
        {
            if (playerCollisionHandler == null)
            {
                return;
            }

            playerCollisionHandler.ObstacleHit += HandleObstacleHit;
            playerCollisionHandler.GoalReached += HandleGoalReached;
        }

        private void OnDisable()
        {
            if (playerCollisionHandler == null)
            {
                return;
            }

            playerCollisionHandler.ObstacleHit -= HandleObstacleHit;
            playerCollisionHandler.GoalReached -= HandleGoalReached;
        }

        private void Start()
        {
            if (startOnStart)
            {
                BeginRun();
            }
        }

        public void BeginRun()
        {
            runActive = true;
            scoreCounter?.ResetScore();
            survivalTimer?.ResetTimer();
            survivalTimer?.StartTimer();
            SetStageScrolling(true);
            gameStateController?.ChangeState(GameState.Playing);
        }

        public void EndRun()
        {
            if (!runActive)
            {
                return;
            }

            runActive = false;
            survivalTimer?.StopTimer();
            SetStageScrolling(false);
            gameStateController?.ChangeState(GameState.GameOver);
        }

        private void HandleObstacleHit()
        {
            if (obstacleHitEndsRun)
            {
                EndRun();
            }
        }

        private void HandleGoalReached()
        {
            scoreCounter?.AddScore(goalScoreBonus);
            EndRun();
        }

        private void SetStageScrolling(bool enabled)
        {
            if (stageScrollers == null)
            {
                return;
            }

            for (int i = 0; i < stageScrollers.Length; i++)
            {
                if (stageScrollers[i] != null)
                {
                    stageScrollers[i].enabled = enabled;
                }
            }
        }
    }
}
