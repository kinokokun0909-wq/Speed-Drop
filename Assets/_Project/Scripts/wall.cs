using UnityEngine;

public class wall : MonoBehaviour
{
    public float speed;
    [SerializeField] private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = new Vector3(0f,speed,0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
