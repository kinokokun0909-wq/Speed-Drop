using System.Collections.Generic;
using UnityEngine;
using SpeedDrop.Data;

namespace SpeedDrop.Stage
{
    public sealed class StageSpawner : MonoBehaviour
    {
        [SerializeField] private List<StageChunk> chunkPrefabs = new();
        [SerializeField] private StageConfig config;
        [SerializeField] private Transform player;
        [SerializeField] private Transform spawnRoot;
        [SerializeField] private int initialChunkCount = 5;
        [SerializeField] private float spawnDistanceBelowPlayer = 80f;
        [SerializeField] private float despawnDistanceAbovePlayer = 30f;

        private readonly List<StageChunk> spawnedChunks = new();

        private void Start()
        {
            int chunkCount = Mathf.Max(initialChunkCount, ActiveChunkCount);
            for (int i = 0; i < chunkCount; i++)
            {
                SpawnNextChunk();
            }
        }

        private void Update()
        {
            RemovePassedChunks();
            RefillChunks();
        }

        public StageChunk SpawnNextChunk()
        {
            if (chunkPrefabs.Count == 0)
            {
                return null;
            }

            StageChunk prefab = chunkPrefabs[Random.Range(0, chunkPrefabs.Count)];
            float length = prefab.Length > 0f ? prefab.Length : ChunkLength;
            Vector3 position = new(transform.position.x, GetNextSpawnTopY() - length * 0.5f, transform.position.z);
            StageChunk chunk = Instantiate(prefab, position, Quaternion.identity, spawnRoot != null ? spawnRoot : transform);
            spawnedChunks.Add(chunk);
            return chunk;
        }

        private void RemovePassedChunks()
        {
            float playerY = player != null ? player.position.y : transform.position.y;
            float despawnY = playerY + DespawnDistanceAbovePlayer;

            for (int i = spawnedChunks.Count - 1; i >= 0; i--)
            {
                StageChunk chunk = spawnedChunks[i];
                if (chunk == null)
                {
                    spawnedChunks.RemoveAt(i);
                    continue;
                }

                if (chunk.BottomY > despawnY)
                {
                    spawnedChunks.RemoveAt(i);
                    Destroy(chunk.gameObject);
                }
            }
        }

        private void RefillChunks()
        {
            while (spawnedChunks.Count < ActiveChunkCount)
            {
                SpawnNextChunk();
            }
        }

        private float ChunkLength => config != null ? config.ChunkLength : 20f;
        private float SpawnDistanceBelowPlayer => config != null ? config.SpawnDistanceBelowPlayer : spawnDistanceBelowPlayer;
        private float DespawnDistanceAbovePlayer => config != null ? config.DespawnDistanceAbovePlayer : despawnDistanceAbovePlayer;
        private int ActiveChunkCount => config != null ? config.ActiveChunkCount : initialChunkCount;

        private float GetNextSpawnTopY()
        {
            float lowestY = float.PositiveInfinity;
            for (int i = 0; i < spawnedChunks.Count; i++)
            {
                StageChunk chunk = spawnedChunks[i];
                if (chunk != null && chunk.BottomY < lowestY)
                {
                    lowestY = chunk.BottomY;
                }
            }

            if (!float.IsPositiveInfinity(lowestY))
            {
                return lowestY;
            }

            float playerY = player != null ? player.position.y : transform.position.y;
            return playerY - SpawnDistanceBelowPlayer;
        }
    }
}
