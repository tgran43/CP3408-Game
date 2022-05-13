using System.Collections;
using UnityEngine;

// A very simplistic car driving on the x-z plane.

public class Drive : MonoBehaviour
{
    // Player speed
    public float speed;

    public float cooldownTime;
    public float timeBetweenDash;
    public SpriteRenderer dashIndicator;
    private bool canDash = true;
    public GameObject player;
    private Collider2D collider2D;
    private Animator animator;

    void Start()
    {
        speed = PlayerPrefs.GetFloat("Speed");
        collider2D = player.GetComponent<Collider2D>();
        animator = player.GetComponent<Animator>();
    }

    void Update()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * speed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, translation, 0);

        // Rotate around our y-axis
        transform.Translate(rotation, 0, 0);


        if (Time.time > cooldownTime)
        {
            Debug.Log("test");
            cooldownTime = Time.time + timeBetweenDash;
            if (canDash == false)
                canDash = !canDash;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canDash == true)
            {
                Debug.Log("dash");
                //animator.SetBool("Dashing", true);
                //animator.SetBool("Dashing", false);
                StartCoroutine(Dash());
                canDash = false;
            }
        }

        dashIndicator.enabled = canDash;
    }

    IEnumerator Dash()
    {
        animator.SetBool("Dashing",true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("Dashing", false);
    }

        
}