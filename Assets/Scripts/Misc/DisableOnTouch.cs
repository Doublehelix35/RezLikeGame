using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnTouch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Scenery" || other.name.Contains("Dumb")) // Scenery or dumb bee
        {
            // Disable other gameobject 
            other.gameObject.SetActive(false);
        }
    }
}
