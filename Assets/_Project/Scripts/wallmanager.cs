using UnityEngine;

public class wallmanager : MonoBehaviour
{
    public GameObject wallPrefab;
    public bool arrive;

    void Start()
    {
        if (arrive == true)
        {
            Invoke("SpawnWall", 3f);
        }
    }

    void SpawnWall()
    {
        Instantiate(wallPrefab, transform.position, Quaternion.identity);
    }
}