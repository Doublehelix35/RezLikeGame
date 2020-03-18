using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDelay : MonoBehaviour
{
    public float DelayTime = 1f;

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

        gameObject.SetActive(false);
    }
}
