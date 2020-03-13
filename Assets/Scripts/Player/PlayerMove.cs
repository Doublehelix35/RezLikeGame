using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float PlayerSpeed = 0.1f; // Speed the player can move in the bounds of the offset
    public float MaxOffset = 5f;
    public Transform CenterRef;

    Vector3 CurrentOffset = new Vector3(0f, 0f, 0f);

    public Transform RailsToFollow;
   
    
    void Update()
    {
        // Horizontal movement offset
        if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0.01f)
        {
            CurrentOffset.x += Input.GetAxis("Horizontal") * PlayerSpeed * Time.deltaTime;

            CurrentOffset.x = Mathf.Clamp(CurrentOffset.x, -MaxOffset, MaxOffset);
        }

        // Vertical movement offset
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.01f)
        {            
            CurrentOffset.y += Input.GetAxis("Vertical") * PlayerSpeed * Time.deltaTime;

            CurrentOffset.y = Mathf.Clamp(CurrentOffset.y, -MaxOffset, MaxOffset);
        }       


        // Set position = rails position + offset
        transform.position = new Vector3(RailsToFollow.position.x + CurrentOffset.x, RailsToFollow.position.y + CurrentOffset.y, RailsToFollow.position.z);

        // Face the center
        transform.LookAt(CenterRef);
    }
}
