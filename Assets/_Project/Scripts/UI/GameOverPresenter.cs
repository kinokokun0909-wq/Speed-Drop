using TMPro;
using UnityEngine;
using SpeedDrop.Gameplay;

namespace SpeedDrop.UI
{
    public sealed class GameOverPresenter : MonoBehaviour
    {
        [SerializeField] private GameStateController gameStateController;
        [SerializeField] private TMP_Text gameOverText;

        private void Awake()
        {
            if (gameStateController == null)
            {
                gameStateController = FindFirstObjectByType<GameStateController>();
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
            if (gameOverText != null)
            {
                gameOverText.gameObject.SetActive(state == GameState.GameOver);
            }
        }
    }
}