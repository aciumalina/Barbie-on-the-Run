using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject coinPrefab;

    private void Start()
    {
        groundSpawner= GameObject.FindAnyObjectByType<GroundSpawner>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            groundSpawner.SpawnTile();
            Destroy(gameObject, 5);
        }
    }
    public void SpawnObstacle()
    {
        int[] random_numbers = RandNumber(1, 1, 9);
        foreach (int number in random_numbers) {
            Transform spawnPoint = transform.GetChild(number).transform;
            Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
        }
    }
    int[] RandNumber(int nr, int min, int max)
    {
        HashSet<int> generatedNumbers = new HashSet<int>();
        for (int i = 0; i < 5; i++)
        {
            int randomNumber = UnityEngine.Random.Range(1, 10);
            if (!generatedNumbers.Contains(randomNumber))
            {
                generatedNumbers.Add(randomNumber);
            }
        }
        int[] randomNumbers = generatedNumbers.ToArray();
        return randomNumbers;
    }
    public void SpawnCoins()
    {
        int coinsToSpawn = 7;
        for(int i=0;i< coinsToSpawn;i++)
        {
            GameObject temp = Instantiate(coinPrefab,transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }
    Vector3 GetRandomPointInCollider( Collider collider)
    {
        Vector3 point = new Vector3(
                UnityEngine.Random.Range(collider.bounds.min.x, collider.bounds.max.x),
                UnityEngine.Random.Range(collider.bounds.min.y, collider.bounds.max.y),
                UnityEngine.Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );

        if(point != collider.ClosestPoint(point))
        {
            point=GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }

}
