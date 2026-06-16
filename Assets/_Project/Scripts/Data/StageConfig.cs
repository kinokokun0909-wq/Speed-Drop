using UnityEngine;

namespace SpeedDrop.Data
{
    [CreateAssetMenu(menuName = "Speed Drop/Stage Config", fileName = "StageConfig")]
    public sealed class StageConfig : ScriptableObject
    {
        [SerializeField] private float scrollSpeed = 12f;
        [SerializeField] private float chunkLength = 20f;

        public float ScrollSpeed => scrollSpeed;
        public float ChunkLength => chunkLength;
    }
}
