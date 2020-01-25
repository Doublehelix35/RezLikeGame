using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterRotate : MonoBehaviour
{
    public float RotateSpeed = 1f; // Speed that the center rotates
    public float MaxRotation = 45f; // Max rotation in degrees
    float SpeedOffsetZ = 1.25f; // Make the z axis move faster
    float NegativeRotationOffset = 0.75f; // How negative the rotation should go

    float RotationOffset; // Offset angle
    float RotationOffsetModifier = 0.8f; // Percentage to use of max rotation

    void Start()
    {
        // Calc rotation offset
        RotationOffset = MaxRotation * RotationOffsetModifier;
    }

    void FixedUpdate()
    {
        // Rotate x and z
        transform.localEulerAngles = new Vector3(RotationOffset + Mathf.PingPong(Time.time * RotateSpeed, MaxRotation) - (MaxRotation * NegativeRotationOffset), 
                                             0f, RotationOffset + Mathf.PingPong(Time.time * RotateSpeed * SpeedOffsetZ, MaxRotation) - (MaxRotation * NegativeRotationOffset));
    }
}
