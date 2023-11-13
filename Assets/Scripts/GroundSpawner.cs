using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint;
    int numberOfGround = 15;
    void Start()
    {
        for(int i=0;i< numberOfGround; i++)
        {
            SpawnTile();
        }
    }

    public void SpawnTile()
    {
        GameObject temp=Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

    }
}
