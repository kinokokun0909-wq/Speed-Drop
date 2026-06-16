using UnityEngine;
using SpeedDrop.Gameplay;

namespace SpeedDrop.Core
{
    public sealed class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private GameStateController gameStateController;

        private void Awake()
        {
            if (gameStateController == null)
            {
                gameStateController = FindFirstObjectByType<GameStateController>();
            }
        }

        private void Start()
        {
            gameStateController?.ChangeState(GameState.Playing);
        }
    }
}
