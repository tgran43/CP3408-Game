using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordfish : MonoBehaviour
{

    public float speed;

    private Rigidbody2D swordFishRigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        swordFishRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = swordFishRigidbody2D.position;
        position.x = position.x + Time.deltaTime * speed * -1;
        swordFishRigidbody2D.MovePosition(position);
    }
}
