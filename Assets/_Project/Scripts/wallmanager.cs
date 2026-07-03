using UnityEngine;

public class wallmanager : MonoBehaviour
{GameObject wall = Instantiate(wallPrefab);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        Invoke("Gameobject wall",3f);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Spawnwall(float speed)
    {
        
    }
        
    
}
