using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRails : MonoBehaviour
{
    public float RotateSpeed = 10f; // Speed the player rotates around center of sphere
    public float Radius = 5f; // Distance from center
    public float AxisSpeed = 0.5f; // Speed that axis changes    
    public Transform CenterRef;

    float CurrentRotation = 0f;


    void Start()
    {
        // Set position to center + radius on x axis
        transform.position = new Vector3(CenterRef.position.x + Radius, CenterRef.position.y, CenterRef.position.z);
    }

    void Update()
    {
        // Update current rotation
        CurrentRotation = RotateSpeed * Time.deltaTime;

        // Rotate around center based on up axis
        transform.RotateAround(CenterRef.position, CenterRef.transform.up, CurrentRotation);

        // Rotates everywhere but top and bottom (is out of sync with center square)
        //transform.RotateAround(Center, Vector3.up, CurrentRotation);
    }
}
