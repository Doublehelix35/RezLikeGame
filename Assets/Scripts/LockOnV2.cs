using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockOnV2 : MonoBehaviour
{
    public Image targeticon;
    //List<Image> alltargets = new List<Image>();
    Image[] alltargets;

    public int maxlock;
    //List<GameObject> enemies = new List<GameObject>();
    GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new GameObject[maxlock];
        alltargets = new Image[maxlock];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            for (int i = 0; i < maxlock; i++)
            {
                if (enemies[i] != null)
                {

                    Destroy(enemies[i]);
                    Destroy(alltargets[i]);

                    enemies[i] = null;
                    alltargets[i] = null;

                    //Debug.Log("Succ");
                }
            }
        }

    }

    public void addlock(GameObject enemy)
    {
        for (int i = 0; i < maxlock; i++)
        {
            if (enemies[i] == null)
            {
                enemies[i] = enemy;

                Vector3 mypos = Camera.main.WorldToScreenPoint(enemy.transform.position);
                mypos = new Vector3(mypos.x, mypos.y, 0);

                alltargets[i] = Instantiate(targeticon, mypos, Quaternion.Euler(0, 0, 0));
                alltargets[i].transform.SetParent(GameObject.Find("Canvas").transform);

                break;

                //Debug.Log("Succ");
            }
        }

        //Debug.Log(enemies.Length);
    }
}
