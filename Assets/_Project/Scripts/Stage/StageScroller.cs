using UnityEngine;
using SpeedDrop.Data;

namespace SpeedDrop.Stage
{
    public sealed class StageScroller : MonoBehaviour
    {
        [SerializeField] private StageConfig config;

        private static float currentSpeed;
        private static int speedUpdatedFrame = -1;

        public static void ResetSpeed()
        {
            currentSpeed = 0f;
            speedUpdatedFrame = -1;
        }

        private void Update()
        {
            if (currentSpeed <= 0f)
            {
                currentSpeed = config != null ? config.ScrollSpeed : 12f;
            }

            if (speedUpdatedFrame != Time.frameCount)
            {
                float acceleration = config != null ? config.ScrollAcceleration : 2f;
                float maxSpeed = config != null ? config.MaxScrollSpeed : 28f;
                currentSpeed = Mathf.Min(maxSpeed, currentSpeed + acceleration * Time.deltaTime);
                speedUpdatedFrame = Time.frameCount;
            }

            transform.position += Vector3.up * (currentSpeed * Time.deltaTime);
        }
    }
}
