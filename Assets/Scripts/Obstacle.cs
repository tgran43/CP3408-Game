using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public GameObject obstacle;

    public float maxX;
    public float maxY;

    public float minX;
    public float minY;

    public float timeBetweenSpawn;

    private float spawnTime;

    private float despawnTime;
    // Start is called before the first frame update
    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 2),transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }

        if (Time.time > despawnTime)
        {

        }
    }
}
