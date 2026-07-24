using UnityEngine;



public class wallmanager : MonoBehaviour
{    public GameObject wallPrefab;
    [SerializeField] Playercontr PlayerContr;
    [SerializeField] private GameObject[] wallPrefabs;
    void Start()
    { 
        if (PlayerContr.alive){
              InvokeRepeating("SpawnWall", 3f,3f);}

    }
    private void SpawnWall()
    {
    if (!PlayerContr.alive || wallPrefabs.Length == 0)
        return;

    int index = Random.Range(0, wallPrefabs.Length);
    Instantiate(wallPrefabs[index], transform.position, Quaternion.identity);
    } 
}
    

