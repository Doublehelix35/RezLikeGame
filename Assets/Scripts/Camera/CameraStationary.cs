using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStationary : MonoBehaviour
{
    public Transform PlayerToFollow;
    public Transform CenterRef;
    public float OffsetMagnitude = 1f; // How far behind the rails should it be


    void Start()
    {
        // Get behind rails
        Vector3 behindVec = PlayerToFollow.position - CenterRef.position;

        // Multiply behind vec by magnitude
        behindVec = new Vector3(behindVec.x * OffsetMagnitude, behindVec.y * OffsetMagnitude, behindVec.z * OffsetMagnitude);

        // Set position = rails position + offset
        transform.position = new Vector3(PlayerToFollow.position.x + behindVec.x, PlayerToFollow.position.y + behindVec.y, PlayerToFollow.position.z + behindVec.z);

        // Camera shouldnt be below rails
        if (PlayerToFollow.position.y > transform.position.y)
        {
            // Calc distance on y axis from rails
            float distY = PlayerToFollow.position.y - transform.position.y;

            // Set new position
            transform.position = new Vector3(transform.position.x + OffsetMagnitude, transform.position.y + distY, transform.position.z + OffsetMagnitude);
        }        
    }

}
