using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockOnV2 : MonoBehaviour
{
    public Image targeticon;
    //List<Image> alltargets = new List<Image>();
    Image[] alltargetimages;

    public int maxlock;
    //List<GameObject> enemies = new List<GameObject>();
    GameObject[] enemies;
    public int currentlocknum;

    public GameObject cursorreplacement;

    public GameObject laserPrefab;

    // For condition scene transitions
    SceneController ControllerRef;
    public bool IsBeeScene = false;
    Transform CanvasRef;

    // Shoot to the beat
    IEnumerator coroutine;
    bool IsAbleToShoot = true;
    public float BeatDelay = 0.5f;

    void Start()
    {
        // Init refs
        ControllerRef = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneController>();
        CanvasRef = GameObject.Find("Canvas").transform;

        enemies = new GameObject[maxlock];
        alltargetimages = new Image[maxlock];
        currentlocknum = 0;

        Cursor.visible = false;

        // Start coroutine
        coroutine = ShootToBeat();

        // Call shoot to beat coroutine
        StartCoroutine(coroutine);

    }

    void Update()
    {
        // Fire lasers
        if (Input.GetButtonDown("Fire1") && IsAbleToShoot)
        {
            // Set is able to shoot
            IsAbleToShoot = false;            
        }

        // Update target image positions
        for (int i = 0; i < maxlock; i++)
        {
            if (enemies[i] != null)
            {

                Vector3 mypos = enemies[i].transform.TransformPoint(enemies[i].GetComponent<BoxCollider>().center);
                mypos = Camera.main.WorldToScreenPoint(mypos);
                mypos = new Vector3(mypos.x, mypos.y, 0);

                alltargetimages[i].transform.position = mypos;                
            }
        }

        //cursorreplacement.transform.position = Camera.main.WorldToScreenPoint(Input.mousePosition);
        //cursorreplacement.transform.position = (new Vector3(cursorreplacement.transform.position.x, cursorreplacement.transform.position.y, 0));
        cursorreplacement.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

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

                alltargetimages[i] = Instantiate(targeticon, mypos, Quaternion.Euler(0, 0, 0));
                alltargetimages[i].transform.SetParent(CanvasRef);

                //alltargets[i].name = "Target " + i;

                currentlocknum ++;

                break;
            }
        }
    }

    internal void purge(GameObject enemy)
    {
        for (int i = 0; i < maxlock; i++)
        {
            if (enemies[i] == enemy)
            {
                /*var laserspawn = Instantiate(laserprefab);
                laserspawn.GetComponent<LaserPositions>().enemy = enemies[i];*/

                //Destroy(enemies[i]);
                Destroy(alltargetimages[i].gameObject);

                enemies[i] = null;
                alltargetimages[i] = null;

                currentlocknum = 0;
            }
        }
    }

    IEnumerator ShootToBeat()
    {
        while (true)
        {
            // Wait until is able to shoot is false
            yield return new WaitUntil(() => !IsAbleToShoot);

            if (!IsAbleToShoot)
            {
                // Shoot all locked on enemies
                for (int i = 0; i < maxlock; i++)
                {
                    if (enemies[i] != null)
                    {
                        GameObject laserSpawn = Instantiate(laserPrefab);
                        laserSpawn.GetComponent<LaserPositions>().enemy = enemies[i];

                        if (enemies[i].tag == "Snake")
                        {
                            GameObject.Find("SnakeHead").GetComponent<SnakeManager>().LoseHealth(1);
                            enemies[i].GetComponent<LockOnV1>().locked = false;
                        }
                        else if (enemies[i].tag == "Ring")
                        {
                            enemies[i].GetComponent<BeeSpawner>().OnBeeDestroy();
                            Destroy(enemies[i]);
                        }
                        else if (enemies[i].tag == "Bee")
                        {
                            if (IsBeeScene)
                            {
                                // Increase condition count
                                ControllerRef.AddToConditionCount();
                                enemies[i].GetComponent<LockOnV1>().locked = false;
                                enemies[i].SetActive(false);
                            }
                            else
                            {
                                enemies[i].GetComponent<LockOnV1>().locked = false;
                                enemies[i].SetActive(false);
                            }
                        }
                        else
                        {
                            Destroy(enemies[i]);
                        }

                        Destroy(alltargetimages[i].gameObject);

                        enemies[i] = null;
                        alltargetimages[i] = null;

                        currentlocknum = 0;

                        yield return new WaitForSeconds(BeatDelay);
                    }
                }

                // Reset is able to shoot
                IsAbleToShoot = true;
            }            
        }    
    }
}
