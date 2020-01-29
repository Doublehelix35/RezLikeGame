using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingRotate : MonoBehaviour
{
    public float RotateSpeed = 10f; // Speed the player rotates around center of sphere 
    public Transform CenterRef;

    float CurrentRotation = 0f;


    void Start()
    {
        // Set position to center
        transform.position = CenterRef.position;
    }

    void Update()
    {
        // Update current rotation
        CurrentRotation = RotateSpeed * Time.deltaTime;

        // Rotate around center based on forward axis
        transform.RotateAround(CenterRef.position, transform.forward, CurrentRotation);

        // Rotate around center based on up axis
        transform.RotateAround(CenterRef.position, transform.up, CurrentRotation);
    }
}
