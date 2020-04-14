using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSting : MonoBehaviour
{
    private Animator Anim;
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Anim.SetBool("Sting", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Anim.SetBool("Sting", false);
        }
    }
}
