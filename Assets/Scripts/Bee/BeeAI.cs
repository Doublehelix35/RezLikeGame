using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BeeAI : MonoBehaviour
{
    GameObject PlayerRef;
    public float Speed = 1f;

    Rigidbody Rigid;


    void Start()
    {
        Rigid = GetComponent<Rigidbody>();
        PlayerRef = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if(PlayerRef != null)
        {
            // Head to player
            Vector3 dir = PlayerRef.transform.position - transform.position;

            Rigid.AddForce(dir * Speed, ForceMode.Force);

            // Face the player
            transform.LookAt(PlayerRef.transform);
        }
    }
        
}
