using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BeeAI : MonoBehaviour
{
    Transform PlayerRef;
    public float Speed = 1f;
    float SpeedOffset = 800f;

    Rigidbody Rigid;
    
    public bool OnlyTargetIsPlayer = true;

    // For bees which use temp target
    Transform TempTargetRef;
    float DelayTime = 2f;
    bool HasSwitchedTargets = false;
    IEnumerator coroutine;

    void Start()
    {
        // Init refs
        Rigid = GetComponent<Rigidbody>();
        PlayerRef = GameObject.FindGameObjectWithTag("Player").transform;

        if (!OnlyTargetIsPlayer)
        {
            TempTargetRef = GameObject.FindGameObjectWithTag("TempTarget").transform;

            // Start coroutine
            coroutine = ChangeTarget();
            StartCoroutine(coroutine);
        }
        
    }

    void FixedUpdate()
    {
        if(PlayerRef != null)
        {
            if (OnlyTargetIsPlayer)
            {
                // Head to player
                Vector3 dir = PlayerRef.position - transform.position;
                dir = dir.normalized;

                Rigid.velocity = dir * Speed * SpeedOffset * Time.fixedDeltaTime;
            }
            else
            {
                // Head to player or temp target
                Vector3 target = HasSwitchedTargets ? PlayerRef.transform.position : TempTargetRef.position;
                Vector3 dir = target - transform.position;
                //dir = dir.normalized;

                Rigid.AddForce(dir * Speed, ForceMode.Force);                            
            }

            // Face the player
            transform.LookAt(PlayerRef);
        }
    }

    IEnumerator ChangeTarget()
    {
        yield return new WaitForSeconds(DelayTime);

        // Change target
        HasSwitchedTargets = true;
    }
}
