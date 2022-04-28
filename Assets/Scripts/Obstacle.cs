using System.Collections;
using TMPro;
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
    public float timeBetweenScore;


    private float spawnTime;
    private float scoreTime;

    private int numObstacles = 4;
    private int score;
    private int seconds;
    private int minutes;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    // Start is called before the first frame update
    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        //int randomObstacle = 2;
        int randomObstacle = Random.Range(numObstacles - numObstacles + 1, numObstacles + 1);
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
                Instantiate(spikeGameObject, transform.position + new Vector3(randomX, 34, 0), transform.rotation);
            }
            //Upwards
            else
            {
                Instantiate(spikeGameObject, transform.position + new Vector3(randomX, -30, 0), Quaternion.Euler(0, 0, 180));
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
            timeBetweenSpawn -= 0.05f;
            if (timeBetweenSpawn < 1)
            {
                timeBetweenSpawn = 1;
            }
        }
        if (Time.time > scoreTime)
        {
            scoreTime = Time.time + timeBetweenScore;
            score += 10;
            seconds += 1;
            scoreText.text = "Score: " + score;
            if (seconds == 60)
            {
                seconds = 0;
                minutes += 1;
            }
            if (seconds < 10)
            {
                timerText.text = "Time: " + minutes + ":0" + seconds;
            }
            else
            {
                timerText.text = "Time: " + minutes + ":" + seconds;
            }
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
