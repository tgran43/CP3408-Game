using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{

    public GameObject spikeGameObject;
    public GameObject jellyFishGameObject;
    public GameObject swordFishGameObject;
    public GameObject mineGameObject;
    public GameObject player;
    public GameObject manager;
    public SpriteRenderer arrow;

    public float maxX;
    public float maxY;

    public float minX;
    public float minY;

    public float timeBetweenSpawn;

    private float spawnTime;
    private int numObstacles = 4;
    
    
    // Start is called before the first frame update
    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        int randomObstacle = Random.Range(numObstacles - numObstacles + 1, numObstacles + 2);
        float swordX;
        float swordY;
        float swordZ;
        //Debug.Log(randomObstacle);
        //Spawn Spike either facing upwards or downwards
        if (randomObstacle == 1)
        {
            int upOrDown = Random.Range(1, 3);
            Debug.Log(upOrDown);
            //Downwards
            if (upOrDown == 1)
            {
                Instantiate(spikeGameObject, transform.position + new Vector3(randomX, 48, 0), transform.rotation);
            }
            //Upwards
            else
            {
                Instantiate(spikeGameObject, transform.position + new Vector3(randomX, -48, 0), Quaternion.Euler(0, 0, 180));
            }
        }
        //Jellyfish
        else if (randomObstacle == 2)
        {
            Instantiate(jellyFishGameObject, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        }
        else if (randomObstacle == 3)
        {
            Instantiate(mineGameObject, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        }
        else if (randomObstacle == 4)
        {
            
            swordY = player.transform.position.y;
            StartCoroutine(swordfishSpawn(swordY));
            
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
        
    }

    IEnumerator swordfishSpawn(float swordY)
    {
        int count = 0;
        SpriteRenderer arrowInstantiate = Instantiate(arrow, transform.position + new Vector3(-10, swordY, 0), Quaternion.Euler(0, 180, 0), manager.transform);
        while (count != 5)
        {
            yield return new WaitForSeconds(0.2f);
            arrowInstantiate.enabled = true;
            yield return new WaitForSeconds(0.2f);
            arrowInstantiate.enabled = false;
            count++;
        }
        Instantiate(swordFishGameObject, transform.position + new Vector3(120, swordY, 0), Quaternion.Euler(0, 180, 0));


    }
}
