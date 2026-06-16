using System;
using UnityEngine;

namespace SpeedDrop.Gameplay
{
    public sealed class GameStateController : MonoBehaviour
    {
        public event Action<GameState> StateChanged;

        [SerializeField] private GameState currentState = GameState.Boot;

        public GameState CurrentState => currentState;

        public void ChangeState(GameState nextState)
        {
            if (currentState == nextState)
            {
                return;
            }

            currentState = nextState;
            StateChanged?.Invoke(currentState);
        }
    }
}
