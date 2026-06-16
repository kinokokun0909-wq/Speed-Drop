using UnityEngine;

namespace SpeedDrop.Data
{
    [CreateAssetMenu(menuName = "Speed Drop/Stage Config", fileName = "StageConfig")]
    public sealed class StageConfig : ScriptableObject
    {
        [SerializeField] private float scrollSpeed = 12f;
        [SerializeField] private float chunkLength = 20f;
        [SerializeField] private float spawnDistanceBelowPlayer = 80f;
        [SerializeField] private float despawnDistanceAbovePlayer = 30f;
        [SerializeField] private int activeChunkCount = 6;

        public float ScrollSpeed => scrollSpeed;
        public float ChunkLength => chunkLength;
        public float SpawnDistanceBelowPlayer => spawnDistanceBelowPlayer;
        public float DespawnDistanceAbovePlayer => despawnDistanceAbovePlayer;
        public int ActiveChunkCount => activeChunkCount;
    }
}
