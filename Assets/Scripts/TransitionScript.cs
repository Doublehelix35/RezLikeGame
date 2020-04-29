using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScript : MonoBehaviour
{
    public GameObject scenecontrols;

    public void levelswap()
    {
        if (GetComponent<Animator>().GetBool("Exiting")) scenecontrols.GetComponent<SceneController>().LoadLevel();
    }
}
