using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string NextLevelName;

    public bool UseTimer = false;
    public float TimerDelay = 0f;

    public int scenenumberino = 1;

    IEnumerator coroutine;

    void Start()
    {
        // Start coroutine
        if (UseTimer)
        {
            coroutine = GoToNextLevel();
            StartCoroutine(coroutine);
        }        
    }

    IEnumerator GoToNextLevel()
    {
        yield return new WaitForSeconds(TimerDelay);

        LoadLevel();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(NextLevelName);

        scenenumberino ++;
    }
}
