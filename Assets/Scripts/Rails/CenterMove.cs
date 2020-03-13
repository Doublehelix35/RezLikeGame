using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterMove : MonoBehaviour
{
    Vector3 CenterPos; // Start position
    public float MaxDistance; // Max distance to travel in direction
    public Vector3 Direction; // Direction to move
    public float Speed = 1f;


    void Start()
    {
        CenterPos = transform.position;
    }

    void Update()
    {
        // Set position = Center position + direction * 0% to 100% of max distance * speed * time.deltatime
        Vector3 newPos = new Vector3(CenterPos.x + (Direction.x * Mathf.PingPong(Time.time * Speed, MaxDistance)),
                                     CenterPos.y + (Direction.y * Mathf.PingPong(Time.time * Speed, MaxDistance)),
                                     CenterPos.z + (Direction.z * Mathf.PingPong(Time.time * Speed, MaxDistance)));

        transform.position = newPos;
    }
}
