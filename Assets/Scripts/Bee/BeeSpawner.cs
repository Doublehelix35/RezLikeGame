using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeeSpawner : MonoBehaviour
{
    public GameObject BeePrefab;

    public int MaxBeesToSpawn = 2; // Maxium bees
    public int MinBeesToSpawn = 0;

    public string CurrentSceneName; // Start scene name

    SceneController ControllerRef;

    void Start()
    {
        // Init controller ref
        ControllerRef = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneController>();
    }

    internal void OnBeeDestroy()
    {
        if (BeePrefab != null)
        {
            int randBeesNum = Random.Range(MinBeesToSpawn, MaxBeesToSpawn + 1);

            for (int i = 0; i < randBeesNum; i++)
            {
                GameObject GO = Instantiate(BeePrefab, transform.position, Quaternion.identity);
            }

            // Increase condition count
            ControllerRef.AddToConditionCount();
        }
        else
        {
            Debug.Log("Bee prefab is null");
        }
    }
}
