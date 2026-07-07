using UnityEngine;

public class wallmanager : MonoBehaviour
{    public GameObject wallPrefab;
    void Start()
    { 
        if (Playercontr.alive == true){
              InvokeRepeating("SpawnWall", 3f,3f);
            
    }

    }
     void SpawnWall()
    {
        Instantiate(wallPrefab, transform.position, Quaternion.identity);
    }
}
