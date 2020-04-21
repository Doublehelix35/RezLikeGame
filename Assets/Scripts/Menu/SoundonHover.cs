using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundonHover : MonoBehaviour
{
    public AudioClip mbutthover;
    public AudioSource Button;

    //script for menu noise
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseOver()
    {
        Button.clip = mbutthover;

        Button.PlayOneShot(mbutthover);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
