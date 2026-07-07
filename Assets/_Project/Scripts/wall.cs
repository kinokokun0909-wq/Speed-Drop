using UnityEngine;

public class Wall : MonoBehaviour
{   [SerializeField] Playercontr PlayerContr;
    public float speed = 5f;

    void Update()
    {   
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (PlayerContr.alive == false)
        {
            speed = 0f;
        }
    }
}