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

        private Vector2 moveInput;

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
            float speed = config != null ? config.MoveSpeed : 8f;
            Vector3 velocity = body.linearVelocity;
            velocity.x = moveInput.x * speed;
            body.linearVelocity = velocity;
        }
    }
}
