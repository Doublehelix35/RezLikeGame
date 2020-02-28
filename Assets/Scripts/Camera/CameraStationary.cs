using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStationary : MonoBehaviour
{
    public Transform PlayerToFollow;
    public Transform CenterRef;

    public Vector3 OffsetMagnitude; // How far behind the rails should it be


    void Start()
    {
        // Set position = player position + offset
        transform.position = new Vector3(PlayerToFollow.position.x + OffsetMagnitude.x, PlayerToFollow.position.y + OffsetMagnitude.y, PlayerToFollow.position.z + OffsetMagnitude.z);

        // Camera shouldnt be below player
        if (PlayerToFollow.position.y > transform.position.y)
        {
            // Set y axis equal to player to follow y axis
            transform.position = new Vector3(transform.position.x, PlayerToFollow.position.y, transform.position.z);
        }        
    }

}
