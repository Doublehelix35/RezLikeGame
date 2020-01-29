using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float PlayerSpeed = 0.1f; // Speed the player can move in the bounds of the offset
    public float MaxOffset = 5f;
    
    Vector3 CurrentOffset = new Vector3(0f, 0f, 0f);

    public Transform RailsToFollow;
   
    
    void Update()
    {
        // Check for offset changes
        if (Input.GetKey(KeyCode.LeftArrow)) // X axis
        {
            CurrentOffset.x += PlayerSpeed * Time.deltaTime;

            CurrentOffset.x = Mathf.Clamp(CurrentOffset.x, -MaxOffset, MaxOffset);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            CurrentOffset.x -= PlayerSpeed * Time.deltaTime;

            CurrentOffset.x = Mathf.Clamp(CurrentOffset.x, -MaxOffset, MaxOffset);
        }

        if (Input.GetKey(KeyCode.UpArrow)) // Y axis
        {
            CurrentOffset.y += PlayerSpeed * Time.deltaTime;

            CurrentOffset.y = Mathf.Clamp(CurrentOffset.y, -MaxOffset, MaxOffset);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            CurrentOffset.y -= PlayerSpeed * Time.deltaTime;

            CurrentOffset.y = Mathf.Clamp(CurrentOffset.y, -MaxOffset, MaxOffset);
        }

        // Set position = rails position + offset
        transform.position = new Vector3(RailsToFollow.position.x + CurrentOffset.x, RailsToFollow.position.y + CurrentOffset.y, RailsToFollow.position.z);
    }
}
