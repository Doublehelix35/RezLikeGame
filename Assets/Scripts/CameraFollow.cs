using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform RailsToFollow;
    public Transform CenterRef;
    public float RadiusOffset = 1f; // Distance from center offset
    public float OffsetMagnitude = 1f; // How far behind the rails should it be


    // Start is called before the first frame update
    void Start()
    {        
        // Radius = distance between rails and center + radius offset
        float radius = Vector3.Distance(RailsToFollow.position, CenterRef.position); 
        radius += RadiusOffset;

        // Set position to center + radius on x axis
        transform.position = new Vector3(CenterRef.position.x + radius, CenterRef.position.y, CenterRef.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        // Get behind rails
        Vector3 behindVec = RailsToFollow.position - CenterRef.position;

        // Multiply behind vec by magnitude
        behindVec = new Vector3(behindVec.x * OffsetMagnitude, behindVec.y * OffsetMagnitude, behindVec.z * OffsetMagnitude);

        // Set position = rails position + offset
        transform.position = new Vector3(RailsToFollow.position.x + behindVec.x, RailsToFollow.position.y + behindVec.y, RailsToFollow.position.z + behindVec.z);

        // Camera shouldnt be below rails
        if(RailsToFollow.position.y > transform.position.y)
        {
            // Calc distance on y axis from rails
            float distY = RailsToFollow.position.y - transform.position.y;

            // Set new position
            transform.position = new Vector3(transform.position.x + OffsetMagnitude, transform.position.y + distY, transform.position.z + OffsetMagnitude);
        }

        // Face the center
        transform.LookAt(CenterRef);
    }
}
