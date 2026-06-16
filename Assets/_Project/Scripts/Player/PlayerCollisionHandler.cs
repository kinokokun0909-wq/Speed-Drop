using System;
using UnityEngine;

namespace SpeedDrop.Player
{
    public sealed class PlayerCollisionHandler : MonoBehaviour
    {
        public event Action ObstacleHit;
        public event Action GoalReached;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Obstacle"))
            {
                ObstacleHit?.Invoke();
                return;
            }

            if (other.CompareTag("Goal"))
            {
                GoalReached?.Invoke();
            }
        }
    }
}
