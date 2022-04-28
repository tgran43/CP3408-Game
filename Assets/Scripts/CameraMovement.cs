using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float cameraSpeed;

    public float speedTimer;

    private float speedTime;
    // Update is called once per frame
    void Update()
    {
        if (Time.time > speedTimer)
        {
            cameraSpeed += 0.01f;
            speedTimer = Time.time + speedTime;
        }
        transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
    }
}
