using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public GameObject Panel1;


    // Start is called before the first frame update
    void Start()
    {
        Panel1.SetActive(false);
    }

    public void PanelOn()
    {
        Panel1.SetActive(true);
    }
    public void PanelOff()
    {
        Panel1.SetActive(false);
    }
}
