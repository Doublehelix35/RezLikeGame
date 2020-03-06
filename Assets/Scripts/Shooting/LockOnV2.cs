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
    public int currentlocknum;

    public GameObject cursorreplacement;

    public GameObject laserprefab;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new GameObject[maxlock];
        alltargets = new Image[maxlock];
        currentlocknum = 0;

        Cursor.visible = false;
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
                    var laserspawn = Instantiate(laserprefab);
                    laserspawn.GetComponent<LaserPositions>().enemy = enemies[i];

                    if (enemies[i].tag == "Snake")
                    {
                        GameObject.Find("SnakeHead").GetComponent<SnakeManager>().LoseHealth(1);
                    }
                    else
                    {
                        Destroy(enemies[i]);
                    }

                    Destroy(alltargets[i].gameObject);

                    enemies[i] = null;
                    alltargets[i] = null;

                    currentlocknum = 0;

                    //Debug.Log("Succ");
                }
            }
        }

        for (int i = 0; i < maxlock; i++)
        {
            if (enemies[i] != null)
            {

                Vector3 mypos = enemies[i].transform.TransformPoint(enemies[i].GetComponent<BoxCollider>().center);
                mypos = Camera.main.WorldToScreenPoint(mypos);
                mypos = new Vector3(mypos.x, mypos.y, 0);

                alltargets[i].transform.position = mypos;

                //Debug.Log("Succ");
            }
        }

        //cursorreplacement.transform.position = Camera.main.WorldToScreenPoint(Input.mousePosition);
        //cursorreplacement.transform.position = (new Vector3(cursorreplacement.transform.position.x, cursorreplacement.transform.position.y, 0));
        cursorreplacement.transform.position = (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

    }

    public void addlock(GameObject enemy)
    {
        for (int i = 0; i < maxlock; i++)
        {
            if (enemies[i] == null)
            {
                enemies[i] = enemy;

                Vector3 mypos = enemy.transform.TransformPoint(enemy.GetComponent<BoxCollider>().center);
                mypos = Camera.main.WorldToScreenPoint(mypos);
                
                mypos = new Vector3(mypos.x, mypos.y, 0);

                alltargets[i] = Instantiate(targeticon, mypos, Quaternion.Euler(0, 0, 0));
                alltargets[i].transform.SetParent(GameObject.Find("Canvas").transform);

                //alltargets[i].name = "Target " + i;

                //Debug.Log(enemies[i].name);

                currentlocknum += 1;

                break;

                
            }
        }

        //Debug.Log(enemies.Length);
    }

    public void purge(GameObject enemy)
    {
        for (int i = 0; i < maxlock; i++)
        {
            if (enemies[i] == enemy)
            {
                /*var laserspawn = Instantiate(laserprefab);
                laserspawn.GetComponent<LaserPositions>().enemy = enemies[i];*/

                Destroy(enemies[i]);
                Destroy(alltargets[i].gameObject);

                enemies[i] = null;
                alltargets[i] = null;

                currentlocknum = 0;

                //Debug.Log("Succ");
            }
        }
    }
}
