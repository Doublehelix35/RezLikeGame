using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterRotate : MonoBehaviour
{

    public float RotateSpeed = 1f; // Speed that the center rotates
    public float MaxRotation = 45f; // Max rotation in degrees

    void FixedUpdate()
    {
        // Set random rotation percentage
        float randX = Random.Range(0f, 1f);
        float randZ = Random.Range(0f, 1f);

        // Ping pong between -1f and 1f
        float pingX = Mathf.PingPong(Time.time, 2f) - 1f;
        float pingZ = Mathf.PingPong(Time.time, 2f) - 1f;

        // Combine rand and ping
        randX *= pingX;
        randZ *= pingZ;

        // Rotate center
        transform.Rotate(randX * RotateSpeed, 0f, randZ * RotateSpeed);

        // Clamp rotation
        Vector3 clampRotation = transform.localEulerAngles;
        clampRotation.x = Mathf.Clamp(clampRotation.x, -MaxRotation, MaxRotation);
        clampRotation.y = 0f;
        clampRotation.z = Mathf.Clamp(clampRotation.z, -MaxRotation, MaxRotation);
        transform.rotation = Quaternion.Euler(clampRotation);
    }
}
