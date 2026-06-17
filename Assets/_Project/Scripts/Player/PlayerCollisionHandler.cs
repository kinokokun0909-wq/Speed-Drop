using System;
using UnityEngine;

namespace SpeedDrop.Player
{
    public sealed class PlayerCollisionHandler : MonoBehaviour
    {
        public event Action ObstacleHit;
        public event Action GoalReached;

        [SerializeField] private string obstacleTag = "Obstacle";
        [SerializeField] private string goalTag = "Goal";

        private void OnTriggerEnter(Collider other)
        {
            HandleContact(other);
        }

        private void OnTriggerStay(Collider other)
        {
            HandleContact(other);
        }

        private void OnCollisionEnter(Collision collision)
        {
            HandleContact(collision.collider);
        }

        private void OnCollisionStay(Collision collision)
        {
            HandleContact(collision.collider);
        }

        private void HandleContact(Collider other)
        {
            if (other == null)
            {
                return;
            }

            if (HasTagInHierarchy(other, obstacleTag))
            {
                Time.timeScale = 0f;
                ObstacleHit?.Invoke();
                return;
            }

            if (HasTagInHierarchy(other, goalTag))
            {
                GoalReached?.Invoke();
            }
        }

        private static bool HasTagInHierarchy(Collider other, string tagName)
        {
            if (string.IsNullOrWhiteSpace(tagName))
            {
                return false;
            }

            Transform current = other.transform;
            while (current != null)
            {
                if (current.gameObject.tag == tagName)
                {
                    return true;
                }

                current = current.parent;
            }

            return false;
        }
    }
}
