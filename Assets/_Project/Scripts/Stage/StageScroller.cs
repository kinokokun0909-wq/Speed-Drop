using UnityEngine;
using SpeedDrop.Data;

namespace SpeedDrop.Stage
{
    public sealed class StageScroller : MonoBehaviour
    {
        [SerializeField] private StageConfig config;

        private void Update()
        {
            float speed = config != null ? config.ScrollSpeed : 12f;
            transform.position += Vector3.up * (speed * Time.deltaTime);
        }
    }
}
