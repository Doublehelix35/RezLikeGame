using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SnakeAi : MonoBehaviour
{
    public bool IsSnakeHead = false;

    public Transform PartToFollow;

    public float FollowSpeed = 0.1f;

    public float MinFollowDistance = 2f;

    Rigidbody rigid;


    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        // Calc dist
        float distance = Vector3.Distance(PartToFollow.position, transform.position);
        Vector3 Dir = PartToFollow.position - transform.position;

        if (distance > MinFollowDistance)
        {            
            rigid.AddForce(Dir * FollowSpeed);
        }
        else
        {
            rigid.AddForce(Dir * (FollowSpeed / distance));
        }

        // Face part to follow
        transform.LookAt(PartToFollow);
    }
}
