using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnTouch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Scenery")
        {
            // Disable other gameobject 
            other.gameObject.SetActive(false);
        }
    }
}
