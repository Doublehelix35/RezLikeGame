using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject PrefabToSpawn;

    public float SpawnRadius = 1f;

    public float SpawnFrequency = 1f; // In seconds
    public const float SpawnFrequencyMaxRandom = 0.5f;
    float SpawnFrequencyRandom = 0f;

    [Range(0, 1)]
    public float SpawnChance;

    IEnumerator coroutine;


    void Start()
    {
        // Start coroutine
        coroutine = SpawnPrefab();
        StartCoroutine(coroutine);
    }

    IEnumerator SpawnPrefab()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnFrequency + SpawnFrequencyRandom);

            float randChance = Random.Range(0f, 1f);

            // Random chance to spawn bee
            if(randChance <= SpawnChance)
            {
                float randX = Random.Range(-SpawnRadius, SpawnRadius);
                float randY = Random.Range(-SpawnRadius, SpawnRadius);
                float randZ = Random.Range(-SpawnRadius, SpawnRadius);

                // Spawn prefab
                Vector3 pos = new Vector3(transform.position.x + randX, transform.position.y + randY, transform.position.z + randZ);
                Instantiate(PrefabToSpawn, pos, transform.rotation);

                // Change spawn frequency random
                SpawnFrequencyRandom = Random.Range(-SpawnFrequencyMaxRandom, SpawnFrequencyMaxRandom);
            }            
        }        
    }
}
