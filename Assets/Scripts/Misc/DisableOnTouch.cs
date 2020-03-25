using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnTouch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with " + other.tag);
        if(other.tag == "Scenery")
        {
            // Disable other gameobject 
            other.gameObject.SetActive(false);
        }
    }
}
