using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScript : MonoBehaviour
{
    public GameObject scenecontrols;
    SoundManager SoundManagerRef;

    private void Start()
    {
        SoundManagerRef = GameObject.FindGameObjectWithTag("SoundMan").GetComponent<SoundManager>();
    }

    public void levelswap()
    {
        if (GetComponent<Animator>().GetBool("Exiting"))
        {
            SoundManagerRef.TransitionSound();
            scenecontrols.GetComponent<SceneController>().LoadLevel();
        } 
    }
}
