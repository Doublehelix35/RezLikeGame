using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRails : MonoBehaviour
{
    public float RotateSpeed = 10f; // Speed the player rotates around center of sphere
    public float Radius = 5f; // Distance from center
    public float AxisSpeed = 0.5f; // Speed that axis changes    

    
    Vector3 Center = new Vector3(0f, 0f, 0f); // Center to rotate around
    float CurrentRotation = 0f;

    Vector3 AxisToRotateAround = Vector3.up;
   


    void Start()
    {
        // Set position to center + radius on x axis
        transform.position = new Vector3(Center.x + Radius, Center.y, Center.z);
    }

    void Update()
    {
        // Update current rotation
        CurrentRotation = RotateSpeed * Time.deltaTime;

        // Slowly move axis
        
        
        // Rotate around center based on axis
        transform.RotateAround(Center, AxisToRotateAround, CurrentRotation);
    }
}
