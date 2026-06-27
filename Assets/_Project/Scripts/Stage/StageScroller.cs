using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using SpeedDrop.Data;

namespace SpeedDrop.Stage
{
    public sealed class StageScroller : MonoBehaviour
    {
        [SerializeField] private StageConfig config;
        [FormerlySerializedAs("pageUpAccelerationBoost")]
        [SerializeField] private float upArrowAccelerationBoost = 5f;
        [FormerlySerializedAs("pageDownAccelerationReduction")]
        [SerializeField] private float downArrowDeceleration = 5f;
        [SerializeField] private float minScrollSpeed = 30f;

        private static float currentSpeed;
        private static int speedUpdatedFrame = -1;

        public static float CurrentSpeed => currentSpeed;

        public static void ResetSpeed()
        {
            currentSpeed = 0f;
            speedUpdatedFrame = -1;
        }

        private void Update()
        {
            if (currentSpeed <= 0f)
            {
                float startSpeed = config != null ? config.ScrollSpeed : 12f;
                currentSpeed = Mathf.Max(minScrollSpeed, startSpeed);
            }

            if (speedUpdatedFrame != Time.frameCount)
            {
                float acceleration = GetScrollAcceleration();
                float maxSpeed = config != null ? config.MaxScrollSpeed : 70f;
                float effectiveMaxSpeed = Mathf.Max(minScrollSpeed, maxSpeed);
                currentSpeed = Mathf.Clamp(
                    currentSpeed + acceleration * Time.deltaTime,
                    minScrollSpeed,
                    effectiveMaxSpeed
                );
                speedUpdatedFrame = Time.frameCount;
            }

            transform.position += Vector3.up * (currentSpeed * Time.deltaTime);
        }

        private float GetScrollAcceleration()
        {
            float acceleration = config != null ? config.ScrollAcceleration : 4.5f;
            Keyboard keyboard = Keyboard.current;

            if (keyboard == null)
            {
                return acceleration;
            }

            if (keyboard.upArrowKey.isPressed)
            {
                acceleration += upArrowAccelerationBoost;
            }

            if (keyboard.downArrowKey.isPressed)
            {
                acceleration = -Mathf.Abs(downArrowDeceleration);
            }

            return acceleration;
        }
    }
}
