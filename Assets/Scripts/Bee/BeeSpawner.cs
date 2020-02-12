using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeSpawner : MonoBehaviour
{
    public GameObject BeePrefab;

    public int MaxBeesToSpawn = 2; // Maxium bees
    public int MinBeesToSpawn = 0;


    bool isQuitting = false;

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void OnDestroy()
    {
        if (!isQuitting)
        {
            if (BeePrefab != null)
            {
                int randBeesNum = Random.Range(MinBeesToSpawn, MaxBeesToSpawn + 1);

                for (int i = 0; i < randBeesNum; i++)
                {
                    GameObject GO = Instantiate(BeePrefab, transform.position, Quaternion.identity);
                }
            }
            else
            {
                Debug.Log("Bee prefab is null");
            }
        }                     
    }
}
