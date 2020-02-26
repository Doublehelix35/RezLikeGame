using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SnakeAi : MonoBehaviour
{
    public bool IsSnakeHead = false;

    public Transform ObjectToFollow;

    Rigidbody rigid;

    // Follow speeds and distances
    public float FollowSpeed = 0.1f;
    public float MinFollowDistance = 2f;
    public float StopFollowDistance = 0.1f;

    // Snake head only
    public float OffsetMagnitudeMaxZ = 1f;


    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        if (IsSnakeHead) // Follow and look at player
        {
            // Calc dist
            float distance = Vector3.Distance(ObjectToFollow.position, transform.position);
            Vector3 Dir = ObjectToFollow.position - transform.position;

            Dir.z = Dir.z * Mathf.PingPong(OffsetMagnitudeMaxZ, Time.time);

            Dir = Dir.normalized;

            if (distance > MinFollowDistance)
            {
                rigid.AddForce(Dir * FollowSpeed);
            }
            else
            {
                if (distance < StopFollowDistance) // Less than stop follow distance
                {
                    // Reduce velocity by half
                    rigid.velocity = rigid.velocity / 2;
                }
                else 
                {
                    rigid.AddForce(Dir * FollowSpeed * (distance / MinFollowDistance));
                }
            }

            // Face part to follow
            transform.LookAt(ObjectToFollow);
        }
        else // Look at part to follow
        {
            // Face part to follow
            transform.LookAt(ObjectToFollow);
        }

        
    }
}
