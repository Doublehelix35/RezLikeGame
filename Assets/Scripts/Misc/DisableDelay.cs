using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDelay : MonoBehaviour
{
    public float DelayTime = 1f;
    public bool IsDestroyable = false;

    IEnumerator coroutine;

    void Start()
    {
        // Start coroutine
        coroutine = SpawnPrefab();
        StartCoroutine(coroutine);
    }

    IEnumerator SpawnPrefab()
    {
        yield return new WaitForSeconds(DelayTime);

        if (IsDestroyable)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }        
    }
}
