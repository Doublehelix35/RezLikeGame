using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SoundonHover : MonoBehaviour
{
    public AudioClip mbutthover;
    public AudioSource Button;
    public AudioClip gstart;

    //script for menu noise
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnMouseOver()
    {
        Button.clip = mbutthover;

        Button.Play();
    }

    public void OnMouseDown()
    {
        Button.clip = gstart;

        Button.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
