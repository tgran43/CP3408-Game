using System.Collections;
using System.Threading;
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
    public GameObject coin;
    public SpriteRenderer arrow;

    public float maxX;
    public float maxY;

    public float minX;
    public float minY;

    public float timeBetweenSpawn;
    public float timeBetweenScore;


    public float spawnScaling;
    public float speedTimer;
    private float speedTime;


    private float spawnTime;
    private float scoreTime;

    private int numObstacles = 5;
    private int score;
    private int seconds;
    private int minutes;
    private float waitAmount = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI moneyText;
    

    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;

    }

    // Start is called before the first frame update
    float Spawn()
    {
        float randomX = 20f;
        float randomY = Random.Range(minY, maxY);
        //int randomObstacle = 3;
        int randomObstacle = Random.Range(1, numObstacles + 1);
        Debug.Log(randomObstacle);

        float swordY;

        //Debug.Log(randomObstacle);
        //Spawn Spike either facing upwards or downwards
        if (randomObstacle == 1)
        {
            //int upOrDown = 3;
            int upOrDown = Random.Range(1, 4);
            Debug.Log(upOrDown);
            //Downwards
            if (upOrDown == 1)
            {
                Instantiate(spikeGameObject, transform.position + new Vector3(randomX, 46.35f, 0), transform.rotation);
                
            }
            //Upwards
            else if (upOrDown == 2){
                Instantiate(spikeGameObject, transform.position + new Vector3(randomX, -33.4f, 0), Quaternion.Euler(0, 0, 180));
                
            }
            else
            {
                StartCoroutine(spawnStalactite(2));
                return 10;
            }
        }
        //Jellyfish
        else if (randomObstacle == 2)
        {
            int jellySpawnCondition = Random.Range(0, 2);
            if(jellySpawnCondition ==0)
                Instantiate(jellyFishGameObject, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
            else
            {
                Instantiate(jellyFishGameObject, transform.position + new Vector3(randomX, 56.9f, 0), transform.rotation);
                Instantiate(jellyFishGameObject, transform.position + new Vector3(randomX, -45.5f, 0), transform.rotation);
            }
        }
        else if (randomObstacle == 3)
        {
            int mineSpawnCondition = Random.Range(0, 2);
            int count = 0;
            if (mineSpawnCondition == 0)
                Instantiate(mineGameObject, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
            else if (mineSpawnCondition == 1)

                while (count != 10)
                {
                    Instantiate(mineGameObject, transform.position + new Vector3(20 + (35*count), 54, 0), transform.rotation);
                    Instantiate(mineGameObject, transform.position + new Vector3(20 + (35 * count), -42, 0), transform.rotation);
                    count += 1;
                }
        }
        else if (randomObstacle == 4)
        {

            swordY = player.transform.position.y;
            StartCoroutine(swordfishSpawn(swordY));
            

        }
        else if (randomObstacle == 5)
        {
            Instantiate(coin, transform.position + new Vector3(50, randomY, 0), transform.rotation);
            Instantiate(coin, transform.position + new Vector3(65, randomY, 0), transform.rotation);
            Instantiate(coin, transform.position + new Vector3(80, randomY, 0), transform.rotation);
            
        }
        return 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            spawnTime -= waitAmount;
            StartCoroutine(waitTime(waitAmount));
            waitAmount = Spawn();
            spawnTime = Time.time + timeBetweenSpawn + waitAmount;
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
            spawnScaling += 0.01f;
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
        Destroy(arrowInstantiate);
        Instantiate(swordFishGameObject, transform.position + new Vector3(120, swordY, 0), Quaternion.Euler(0, 180, 0));


    }

    IEnumerator spawnStalactite(float time)
    {
        bool spawn = true;
        while (spawn)
        {
            Instantiate(spikeGameObject, transform.position + new Vector3(20, 46.35f, 0), transform.rotation);
            yield return new WaitForSeconds(time);
            Instantiate(spikeGameObject, transform.position + new Vector3(20, 46.35f, 0), transform.rotation);
            yield return new WaitForSeconds(time);
            Instantiate(spikeGameObject, transform.position + new Vector3(20, -33.4f, 0), Quaternion.Euler(0, 0, 180));
            yield return new WaitForSeconds(time);
            Instantiate(spikeGameObject, transform.position + new Vector3(20, -33.4f, 0), Quaternion.Euler(0, 0, 180));
            yield return new WaitForSeconds(time);
            Instantiate(spikeGameObject, transform.position + new Vector3(20, 46.35f, 0), transform.rotation);
            yield return new WaitForSeconds(time);
            Instantiate(spikeGameObject, transform.position + new Vector3(20, 46.35f, 0), transform.rotation);
            yield return new WaitForSeconds(time);
            spawn = false;
        }
    }

    IEnumerator waitTime(float time)
    {
        yield return new WaitForSeconds(time);
    }


}
