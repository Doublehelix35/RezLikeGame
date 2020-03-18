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

    public bool UseScaleModifier = false; // Picks a random scale between normal and scale modifier

    public Vector3 DefaultScale; // Not all scale is 1,1,1
    public Vector3 ScaleModifierMax; // Max scale for each axis

    public bool RandomXSpawn = true;
    public bool RandomYSpawn = true;
    public bool RandomZSpawn = true;

    public bool RandomXRotation = false;
    public bool RandomYRotation = true;
    public bool RandomZRotation = false;

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
                float randX = 0f;
                float randY = 0f;
                float randZ = 0f;

                if (RandomXSpawn) { randX = Random.Range(-SpawnRadius, SpawnRadius); }
                if (RandomYSpawn) { randY = Random.Range(-SpawnRadius, SpawnRadius); }
                if (RandomZSpawn) { randZ = Random.Range(-SpawnRadius, SpawnRadius); }

                // Spawn prefab
                Vector3 pos = new Vector3(transform.position.x + randX, transform.position.y + randY, transform.position.z + randZ);
                GameObject GO = Instantiate(PrefabToSpawn, pos, transform.rotation);

                float rotX = RandomXRotation ? Random.Range(0, 180) : 0f;
                float rotY = RandomYRotation ? Random.Range(0, 180) : 0f;
                float rotZ = RandomZRotation ? Random.Range(0, 180) : 0f;


                GO.transform.Rotate(new Vector3(rotX, rotY, rotZ));

                if (UseScaleModifier)
                {
                    // Random modifier between default and Scale modifier max
                    Vector3 scaleModifier = new Vector3(Random.Range(DefaultScale.x, ScaleModifierMax.x), 
                                                        Random.Range(DefaultScale.y, ScaleModifierMax.y), 
                                                        Random.Range(DefaultScale.z, ScaleModifierMax.z));

                    GO.transform.localScale = new Vector3(GO.transform.localScale.x * scaleModifier.x,
                                                          GO.transform.localScale.y * scaleModifier.y,
                                                          GO.transform.localScale.z * scaleModifier.z);
                }

                // Change spawn frequency random
                SpawnFrequencyRandom = Random.Range(-SpawnFrequencyMaxRandom, SpawnFrequencyMaxRandom);
            }            
        }        
    }
}
