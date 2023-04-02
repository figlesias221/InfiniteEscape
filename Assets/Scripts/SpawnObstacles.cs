using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstaclePrefab;
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
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(x, y, 0);
        Instantiate(obstaclePrefab, transform.position + spawnPosition, transform.rotation);
    }
}
