using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string NextLevelName;

    public int scenenumberino = 1;

    public int ConditionMin = 1;
    int CurConditionCount = 0;

    public Animator transition;

    //public bool UseTimer = false;
    //public float TimerDelay = 0f;

    //IEnumerator coroutine;

    //void Start()
    //{
    //    // Start coroutine
    //    if (UseTimer)
    //    {
    //        coroutine = GoToNextLevel();
    //        StartCoroutine(coroutine);
    //    }        
    //}

    //IEnumerator GoToNextLevel()
    //{
    //    yield return new WaitForSeconds(TimerDelay);

    //    LoadLevel();
    //}

    public void LoadLevel()
    {
        SceneManager.LoadScene(NextLevelName);

        scenenumberino ++;
    }

    public void AddToConditionCount()
    {
        CurConditionCount++;

        if(CurConditionCount >= ConditionMin)
        {
            // Go to next scene
            //LoadLevel();
            Cursor.visible = true;

            transition.SetBool("Exiting", true);
        }
    }
}
