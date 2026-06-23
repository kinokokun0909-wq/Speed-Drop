using UnityEngine;

namespace SpeedDrop.Data
{
    [CreateAssetMenu(menuName = "Speed Drop/Player Config", fileName = "PlayerConfig")]
    public sealed class PlayerConfig : ScriptableObject
    {
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private float fallSpeed = 18f;
        [SerializeField] private float moveAcceleration = 80f;
        [SerializeField] private float moveDeceleration = 100f;

        public float MoveAcceleration => moveAcceleration;
        public float MoveDeceleration => moveDeceleration;
        public float MoveSpeed => moveSpeed;
        public float FallSpeed => fallSpeed;
    }
}
