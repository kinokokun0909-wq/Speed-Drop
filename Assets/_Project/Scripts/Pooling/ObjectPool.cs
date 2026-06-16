using System.Collections.Generic;
using UnityEngine;

namespace SpeedDrop.Pooling
{
    public sealed class ObjectPool : MonoBehaviour
    {
        [SerializeField] private Poolable prefab;
        [SerializeField] private int preloadCount = 8;

        private readonly Queue<Poolable> pool = new();

        private void Awake()
        {
            for (int i = 0; i < preloadCount; i++)
            {
                CreateInstance();
            }
        }

        public Poolable Get(Vector3 position, Quaternion rotation)
        {
            Poolable instance = pool.Count > 0 ? pool.Dequeue() : CreateInstance();
            instance.transform.SetPositionAndRotation(position, rotation);
            instance.gameObject.SetActive(true);
            return instance;
        }

        public void Release(Poolable instance)
        {
            instance.gameObject.SetActive(false);
            pool.Enqueue(instance);
        }

        private Poolable CreateInstance()
        {
            Poolable instance = Instantiate(prefab, transform);
            instance.SetOwner(this);
            instance.gameObject.SetActive(false);
            pool.Enqueue(instance);
            return instance;
        }
    }
}
