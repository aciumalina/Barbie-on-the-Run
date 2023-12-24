using Unity.VisualScripting;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject coinPrefab;

    Vector3 nextSpawnPoint=new Vector3(0,0,-10);
    int numberOfGround = 3;
    void Start()
    {
        for(int i=0;i< numberOfGround; i++)
        {
            InitialSpawnTile();
        }
    }

    public void InitialSpawnTile()
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(0).transform.position;
    }

    public void SpawnTile()
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        temp.GetComponent<GroundTile>().SpawnObstacle();
        temp.GetComponent<GroundTile>().SpawnCoins();
        nextSpawnPoint = temp.transform.GetChild(0).transform.position;
    }

}
