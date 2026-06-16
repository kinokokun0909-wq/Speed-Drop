using UnityEngine;

namespace SpeedDrop.Data
{
    [CreateAssetMenu(menuName = "Speed Drop/Player Config", fileName = "PlayerConfig")]
    public sealed class PlayerConfig : ScriptableObject
    {
        [SerializeField] private float moveSpeed = 8f;
        [SerializeField] private float fallSpeed = 14f;

        public float MoveSpeed => moveSpeed;
        public float FallSpeed => fallSpeed;
    }
}
