using UnityEngine;

namespace SpeedDrop.Utilities
{
    public sealed class FaceCamera : MonoBehaviour
    {
        [SerializeField] private Camera targetCamera;

        private void LateUpdate()
        {
            Camera cameraToFace = targetCamera != null ? targetCamera : Camera.main;
            if (cameraToFace == null)
            {
                return;
            }

            transform.rotation = Quaternion.LookRotation(transform.position - cameraToFace.transform.position);
        }
    }
}
