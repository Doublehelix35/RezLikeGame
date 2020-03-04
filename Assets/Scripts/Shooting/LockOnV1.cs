using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockOnV1 : MonoBehaviour
{

    public Image target;

    bool locked;
    Image mytarget;

    LockOnV2 mainscript;


    // Start is called before the first frame update
    void Start()
    {
        mainscript = Camera.main.gameObject.GetComponent<LockOnV2>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (locked)
        {
            Vector3 mypos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            mypos = new Vector3(mypos.x, mypos.y, 0);

            //mytarget.transform.position = mypos;

            if (Input.GetButtonDown("Fire1"))
            {
                GameObject.Destroy(mytarget);
                GameObject.Destroy(gameObject);
            }
        }*/
    }

    private void OnMouseEnter()
    {
        if (locked == false && mainscript.currentlocknum != mainscript.maxlock)
        {
            Debug.Log("Moused");

            /*Vector3 mypos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            mypos = new Vector3(mypos.x, mypos.y, 0);

            //mytarget.transform.position = mypos;
            mytarget = Instantiate(target, mypos, Quaternion.Euler(0, 0, 0));
            mytarget.transform.SetParent(GameObject.Find("Canvas").transform);*/

            mainscript.addlock(gameObject);

            locked = true;

            Debug.Log(GetComponent<BoxCollider>().center);
        }
    }

    private void OnDestroy()
    {
        mainscript.purge(gameObject);
    }
}
