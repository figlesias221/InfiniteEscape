using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject[] prefabs;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn = 1f;
    private float timeSinceLastSpawn = 0f;


    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= timeBetweenSpawn)
        {
            Spawn();
            timeSinceLastSpawn = 0f;
        }
    }

    void Spawn()
    {
        int randomPrefabIndex = Random.Range(0, prefabs.Length);
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(x, y, 0);
        // rotate the obstacle 90 degrees if it's a triangle
        if (randomPrefabIndex == 2)
        {
            Instantiate(prefabs[randomPrefabIndex], transform.position + spawnPosition, Quaternion.Euler(0, 0, 90));
        }
        else {
            Instantiate(prefabs[randomPrefabIndex], transform.position + spawnPosition, transform.rotation); 
        }
    }
}
