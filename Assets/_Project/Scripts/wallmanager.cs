using UnityEngine;



public class wallmanager : MonoBehaviour
{    public GameObject wallPrefab;
    [SerializeField] Playercontr PlayerContr;
    void Start()
    { 
        if (PlayerContr.alive){
              InvokeRepeating("SpawnWall", 3f,3f);}

    }
    
    private void SpawnWall()
    {   
        if (!PlayerContr.alive) return;
        Instantiate(wallPrefab, transform.position, Quaternion.identity);
    } 
}
    

