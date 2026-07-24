using UnityEngine;

public class Wall : MonoBehaviour
{   [SerializeField] Playercontr PlayerContr;
    [SerializeField] private float acceleration = 1f;
    [SerializeField] private float maxSpeed = 45f;
    public float speed = 5f;
    
    
    void Update()
    {   
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (PlayerContr.alive == false)
        {
            speed = 0f;
        }
        speed += acceleration * Time.deltaTime;
        speed = Mathf.Min(speed, maxSpeed);
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}