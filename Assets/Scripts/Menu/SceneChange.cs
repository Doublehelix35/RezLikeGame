using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ToGame()
    {
        StartCoroutine(SecenLoading());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator SecenLoading()
    {
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene("BeeScene");
    }
}
