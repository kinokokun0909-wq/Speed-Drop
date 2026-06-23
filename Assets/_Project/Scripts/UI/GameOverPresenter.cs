using TMPro;
using UnityEngine;
using SpeedDrop.Gameplay;

namespace SpeedDrop.UI
{
    public sealed class GameOverPresenter : MonoBehaviour
    {
        [SerializeField] private GameStateController gameStateController;
        [SerializeField] private TMP_Text gameOverText;
        [SerializeField] private GameObject retryButton;
        [SerializeField] private GameObject returnToMenuButton;

        private void Awake()
        {
            if (gameStateController == null)
            {
                gameStateController = FindFirstObjectByType<GameStateController>();
            }
            if (retryButton != null)
            { 
                retryButton.SetActive(false);
            }
            if (returnToMenuButton != null)
            {
                returnToMenuButton.SetActive(false);
            }
            if (gameOverText != null)
            {
                gameOverText.gameObject.SetActive(false);
            }
        }

        private void OnEnable()
        {
            if (gameStateController != null)
            {
                gameStateController.StateChanged += HandleStateChanged;
            }
        }

        private void OnDisable()
        {
            if (gameStateController != null)
            {
                gameStateController.StateChanged -= HandleStateChanged;
            }
        }

        private void Start()
        {
            if (gameStateController != null)
            {
                HandleStateChanged(gameStateController.CurrentState);
            }
        }

        private void HandleStateChanged(GameState state)
        {
          bool isGameOver = state == GameState.GameOver;

            if (gameOverText != null)
            {
                gameOverText.gameObject.SetActive(isGameOver);
            }

            if (retryButton != null)
            {
                retryButton.SetActive(isGameOver);
            }

            if (returnToMenuButton != null)
            {
                returnToMenuButton.SetActive(isGameOver);
            }
        }
    }
}
