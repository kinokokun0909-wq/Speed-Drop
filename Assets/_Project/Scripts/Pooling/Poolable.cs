using UnityEngine;

namespace SpeedDrop.Pooling
{
    public sealed class Poolable : MonoBehaviour
    {
        public ObjectPool Owner { get; private set; }

        public void SetOwner(ObjectPool owner)
        {
            Owner = owner;
        }

        public void Release()
        {
            if (Owner != null)
            {
                Owner.Release(this);
                return;
            }

            gameObject.SetActive(false);
        }
    }
}
