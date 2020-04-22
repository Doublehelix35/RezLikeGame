using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScript : MonoBehaviour
{

    public GameObject scenecontrols;
    Animator myanim;

    // Start is called before the first frame update
    void Start()
    {
        myanim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void levelswap()
    {
        if (myanim.GetBool("Exiting")) scenecontrols.GetComponent<SceneController>().LoadLevel();
    }
}
