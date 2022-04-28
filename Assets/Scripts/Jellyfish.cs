using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : MonoBehaviour
{
    private GameObject player;
    public float speed = 10.0f;

    
    void Start()
    {
        player = GameObject.Find("Player");
    }

    
    void LateUpdate()
    {
        if (this.transform.position.x - player.transform.position.x > 0)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, player.transform.position.y), speed * Time.deltaTime);
    }
}
