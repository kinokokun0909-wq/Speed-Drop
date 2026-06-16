using System;
using UnityEngine;

namespace SpeedDrop.Gameplay
{
    public sealed class SurvivalTimer : MonoBehaviour
    {
        public event Action<float> TimeChanged;

        [SerializeField] private bool running;
        [SerializeField] private float elapsedTime;

        public bool Running => running;
        public float ElapsedTime => elapsedTime;

        public void ResetTimer()
        {
            elapsedTime = 0f;
            TimeChanged?.Invoke(elapsedTime);
        }

        public void StartTimer()
        {
            running = true;
            TimeChanged?.Invoke(elapsedTime);
        }

        public void StopTimer()
        {
            running = false;
            TimeChanged?.Invoke(elapsedTime);
        }

        private void Update()
        {
            if (!running)
            {
                return;
            }

            elapsedTime += Time.deltaTime;
            TimeChanged?.Invoke(elapsedTime);
        }
    }
}
