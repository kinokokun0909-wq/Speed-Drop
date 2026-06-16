using UnityEngine;

namespace SpeedDrop.Stage
{
    public sealed class StageChunk : MonoBehaviour
    {
        [SerializeField] private Transform exitPoint;
        [SerializeField] private float length = 20f;

        public Transform ExitPoint => exitPoint;
        public float Length => length;
        public float TopY => transform.position.y + length * 0.5f;
        public float BottomY => transform.position.y - length * 0.5f;
    }
}
