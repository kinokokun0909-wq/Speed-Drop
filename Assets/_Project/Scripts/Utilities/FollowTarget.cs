using UnityEngine;

namespace SpeedDrop.Utilities
{
    public sealed class FollowTarget : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset = new(0f, 6f, -10f);
        [SerializeField] private float damping = 8f;

        private void LateUpdate()
        {
            if (target == null)
            {
                return;
            }

            Vector3 desiredPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, 1f - Mathf.Exp(-damping * Time.deltaTime));
        }
    }
}
