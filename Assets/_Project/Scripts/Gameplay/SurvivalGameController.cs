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
        [SerializeField] private PlayerController playerController;
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

            if (playerController == null)
            {
                playerController = FindFirstObjectByType<PlayerController>();
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
            Time.timeScale = 1f;
            StageScroller.ResetSpeed();
            runActive = true;
            if (playerController != null)
            {
                playerController.enabled = true;
            }

            scoreCounter?.ResetScore();
            survivalTimer?.ResetTimer();
            survivalTimer?.StartTimer();
            SetStageScrolling(true);
            gameStateController?.ChangeState(GameState.Playing);
        }

        public void EndRun()
        {
            if (!runActive && gameStateController != null && gameStateController.CurrentState == GameState.GameOver)
            {
                FreezeRun();
                return;
            }

            runActive = false;
            gameStateController?.ChangeState(GameState.GameOver);
            FreezeRun();
        }

        private void FreezeRun()
        {
            survivalTimer?.StopTimer();
            SetStageScrolling(false);

            if (playerController != null)
            {
                playerController.StopMovement();
                playerController.enabled = false;
            }

            Time.timeScale = 0f;
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
            if (!runActive)
            {
                return;
            }

            scoreCounter?.AddScore(goalScoreBonus);
            EndRun();
        }

        private void SetStageScrolling(bool enabled)
        {
            if (!enabled || stageScrollers == null || stageScrollers.Length == 0)
            {
                StageScroller[] foundScrollers = FindObjectsByType<StageScroller>(FindObjectsSortMode.None);
                if (foundScrollers.Length > 0)
                {
                    stageScrollers = foundScrollers;
                }
            }

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
