using System.Collections.Generic;
using UnityEngine;

namespace SpeedDrop.Stage
{
    public sealed class StageSpawner : MonoBehaviour
    {
        [SerializeField] private List<StageChunk> chunkPrefabs = new();
        [SerializeField] private Transform spawnRoot;
        [SerializeField] private int initialChunkCount = 5;

        private readonly Queue<StageChunk> spawnedChunks = new();

        private void Start()
        {
            for (int i = 0; i < initialChunkCount; i++)
            {
                SpawnNextChunk();
            }
        }

        public StageChunk SpawnNextChunk()
        {
            if (chunkPrefabs.Count == 0)
            {
                return null;
            }

            StageChunk prefab = chunkPrefabs[Random.Range(0, chunkPrefabs.Count)];
            Vector3 position = spawnedChunks.Count == 0 ? transform.position : spawnedChunks.Peek().ExitPoint.position;
            StageChunk chunk = Instantiate(prefab, position, Quaternion.identity, spawnRoot != null ? spawnRoot : transform);
            spawnedChunks.Enqueue(chunk);
            return chunk;
        }
    }
}
