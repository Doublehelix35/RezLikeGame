using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject PrefabToSpawn;
    List<GameObject> PrefabPool = new List<GameObject>();

    public int MaxPoolSize = 5;

    public float SpawnRadius = 1f;

    public float SpawnFrequency = 1f; // In seconds
    public const float SpawnFrequencyMaxRandom = 0.5f;
    float SpawnFrequencyRandom = 0f;

    [Range(0, 1)]
    public float SpawnChance;

    public bool UseScaleModifier = false; // Picks a random scale between normal and scale modifier
    public bool UseSpawnerRotation = true; // If true uses spawners rotation

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

        // Init prefab pool
        for(int i = 0; i < MaxPoolSize; i++)
        {
            // Spawn object and add to pool
            GameObject GO = Instantiate(PrefabToSpawn);
            GO.SetActive(false); // Set inactive            
            PrefabPool.Add(GO); // Add GO to prefab pool list
        }
    }

    IEnumerator SpawnPrefab()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnFrequency + SpawnFrequencyRandom);

            float randChance = Random.Range(0f, 1f);

            // Random chance to spawn prefab
            if(randChance <= SpawnChance)
            {
                // Temp game object ref
                GameObject GO = GetPooledPrefab(); // Set GO to first available object

                // Only spawn if object available in pool
                if(GO != null)
                {
                    // Random position
                    float randX = 0f;
                    float randY = 0f;
                    float randZ = 0f;

                    if (RandomXSpawn) { randX = Random.Range(-SpawnRadius, SpawnRadius); }
                    if (RandomYSpawn) { randY = Random.Range(-SpawnRadius, SpawnRadius); }
                    if (RandomZSpawn) { randZ = Random.Range(-SpawnRadius, SpawnRadius); }

                    // Set position for prefab spawn
                    Vector3 pos = new Vector3(transform.position.x + randX, transform.position.y + randY, transform.position.z + randZ);

                    // Set up GO
                    GO.transform.position = pos;
                    GO.transform.rotation = UseSpawnerRotation ? transform.rotation : Quaternion.identity;
                    GO.transform.localScale = DefaultScale;

                    // Random rotation
                    float rotX = RandomXRotation ? Random.Range(0, 180) : GO.transform.eulerAngles.x;
                    float rotY = RandomYRotation ? Random.Range(0, 180) : GO.transform.eulerAngles.y;
                    float rotZ = RandomZRotation ? Random.Range(0, 180) : GO.transform.eulerAngles.z;

                    GO.transform.Rotate(new Vector3(rotX, rotY, rotZ));

                    // Random scale
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

                    // Set GO to active
                    GO.SetActive(true);

                    // Change spawn frequency
                    SpawnFrequencyRandom = Random.Range(-SpawnFrequencyMaxRandom, SpawnFrequencyMaxRandom);
                }                
            }            
        }        
    }

    GameObject GetPooledPrefab()
    {
        for(int i = 0; i < PrefabPool.Count; i++)
        {
            if (!PrefabPool[i].activeInHierarchy)
            {
                return PrefabPool[i];
            }
        }
        return null;
    }
}
