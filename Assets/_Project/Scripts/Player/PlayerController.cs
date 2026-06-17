using UnityEngine;
using UnityEngine.InputSystem;
using SpeedDrop.Data;

namespace SpeedDrop.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerConfig config;
        [SerializeField] private InputActionReference moveAction;
        [SerializeField] private Rigidbody body;
        [SerializeField] private bool lockYPosition = true;
        [SerializeField] private bool faceDown = true;
        [SerializeField] private Vector2 xLimits = new(-12f, 12f);
        [SerializeField] private Vector2 zLimits = new(-12f, 12f);

        private Vector2 moveInput;
        private float fixedY;

        private void Reset()
        {
            body = GetComponent<Rigidbody>();
        }

        private void Awake()
        {
            if (body == null)
            {
                body = GetComponent<Rigidbody>();
            }

            fixedY = transform.position.y;

            if (body != null)
            {
                body.useGravity = false;
            }
        }

        private void OnEnable()
        {
            if (moveAction != null)
            {
                moveAction.action.Enable();
            }
        }

        private void OnDisable()
        {
            if (moveAction != null)
            {
                moveAction.action.Disable();
            }
        }

        private void Update()
        {
            moveInput = moveAction != null ? moveAction.action.ReadValue<Vector2>() : Vector2.zero;
        }

        private void FixedUpdate()
        {
            if (body == null)
            {
                return;
            }

            float speed = config != null ? config.MoveSpeed : 8f;
            Vector3 velocity = body.linearVelocity;
            velocity.x = moveInput.x * speed;
            velocity.y = 0f;
            velocity.z = moveInput.y * speed;
            body.linearVelocity = velocity;

            Vector3 position = body.position;
            position.x = Mathf.Clamp(position.x, xLimits.x, xLimits.y);
            position.z = Mathf.Clamp(position.z, zLimits.x, zLimits.y);
            if (lockYPosition)
            {
                position.y = fixedY;
            }

            body.MovePosition(position);

            if (faceDown)
            {
                body.MoveRotation(Quaternion.LookRotation(Vector3.down, Vector3.forward));
            }
        }

        public void StopMovement()
        {
            moveInput = Vector2.zero;

            if (body == null)
            {
                return;
            }

            body.linearVelocity = Vector3.zero;
            body.angularVelocity = Vector3.zero;
        }
    }
}
