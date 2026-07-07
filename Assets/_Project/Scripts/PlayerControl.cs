using UnityEngine;

public class Playercontr : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector2 min;
    [SerializeField] private Vector2 max;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject RetryText;
    [SerializeField] private GameObject BackText;
    [SerializeField] public bool alive;
    private Vector2 inputVector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverText.SetActive(false);
        RetryText.SetActive(false);
        BackText.SetActive(false);
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!alive)
        {
            gameOverText.SetActive(true);
            RetryText.SetActive(true);
            BackText.SetActive(true);
        }

        PlayerInput();
        PlayerMovement();
        MoveRange();
    }
    private void PlayerInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        inputVector = new Vector2(horizontalInput, verticalInput);
    }
    private void PlayerMovement()
    {
        rb.linearVelocity = new Vector3(inputVector.x, 0f, inputVector.y) * moveSpeed;
    }
    private void MoveRange()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, min.x, max.x),
            0f,
            Mathf.Clamp(transform.position.z, min.y, max.y)
        );
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            alive = false;
        }    
    }
}
