using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{

    public AudioSource efxSource; //Audio Source that will Play SFX
    public AudioSource musicSource; //Audio Source that will Play Music

    public AudioClip LockOn;
    public AudioClip Fire;

    public AudioClip Bee;
    public AudioClip BeeDie;

    public AudioClip SquareDie; //Sound for destroying the square things around boss

    public AudioClip BossEnrage; //Sound for when there is a low amount of Squares left
    public AudioClip BossDie; //Sound for when Boss dies/No squares Left.


    public static SoundManager instance = null; //Allows other scripts to call functions from SoundManager
    public GameObject Gameman;
    public int Scenenum;


    //music for scenes
    public AudioClip scene1Music; //BeeScene
    public AudioClip scene2Music; //EggScene
    public AudioClip scene3Music; //SnakeScene
    public AudioClip scene4Music; //WinScene

    bool scene2play = false;
    bool scene3play = false;
    bool scene4play = false;


    public float lowPitchRange = .95f; //Lowest pitch a sfx will be
    public float highPitchRange = 1.05f; //Highest pitch a sfx will be


   public static class AudioFadeOut //Call this for music to Fade OUT
    {
        public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
        {
            float startVolume = audioSource.volume;
            while (audioSource.volume > 0)
            {
                audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
                yield return null;
            }
            audioSource.Stop();
        }
    }

    public static class AudioFadeIn //Call this for Fade In (WIP)
    {
        public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
        {
            audioSource.Play();
            audioSource.volume = 0f;
            while (audioSource.volume < 1)
            {
                audioSource.volume += Time.deltaTime / FadeTime;
                yield return null;
            }
        }
    }


    void Awake()
    {
        //Checks for current instance of Soundmanager
        if (instance == null)
            //if not, set it to this
            instance = this;

        else if (instance != this) //Destroys script

            Destroy(gameObject);

    }

    public void PlayLockOn(AudioClip clip)
    {
        efxSource.clip = LockOn;    //sets Audioclip to desired clip and plays.

        efxSource.Play();

    }

    public void PlayFire(AudioClip clip)
    {
        efxSource.clip = Fire;

        efxSource.Play();

    }

    public void PlayBee(AudioClip clip)
    {
        efxSource.clip = Bee;

        efxSource.Play();

    }

    public void PlayBeeDie(AudioClip clip)
    {
        efxSource.clip = BeeDie;

        efxSource.Play();
    }

    public void PlaySquareDie(AudioClip clip)
    {
        efxSource.clip = SquareDie;

        efxSource.Play();
    }

    public void PlayBossEnrage(AudioClip clip)
    {
        efxSource.clip = BossEnrage;

        efxSource.Play();
    }

    public void PlayBossDie(AudioClip clip)
    {
        efxSource.clip = BossDie;

        efxSource.Play();
    }

    void levelMusicPlay() //Sort this out in game manager
    {
        Scene CurrentScene = SceneManager.GetActiveScene(); //Gets the current Active Scene
        Debug.Log(CurrentScene.name);
        if (CurrentScene.name == "BeeScene")
        {
            if (scene1Music != null)
            {
                musicSource.clip = scene1Music;
                musicSource.Play();
            }

            else
            {
                Debug.LogWarning("Music not found for BeeScene Error Code: BeeBeePooPoo");
            }

        }

        if (CurrentScene.name == "EggScene")
        {
            if (scene2Music != null)
            {
                musicSource.clip = scene2Music;
                musicSource.Play();
            }
            else
            {
                Debug.LogWarning("Music not found for EggScene Error Code: Hard Boiled");
            }
        }

        if (CurrentScene.name == "SnakeScene")
        {

            if(scene3Music != null)
            {
                musicSource.clip = scene3Music;
                musicSource.Play();
            }

            else
            {
                Debug.LogWarning("Music not found for SnakeScene Error Code: Snake in my boot");
            }
        }

        if (CurrentScene.name == "WinScene")
        {
            if(scene4Music != null)
            {
                musicSource.clip = scene4Music;
                musicSource.Play();
            }
            else
            {
                Debug.LogWarning("Music not found for WinScene Error Code: did u really win tho?");
            }

        }


    }

    // Start is called before the first frame update
    void Start()
    {
        musicSource.Play();

        Scenenum = Gameman.GetComponent<SceneController>().scenenumberino;

        levelMusicPlay();
    }

    // Update is called once per frame
    void Update()
    {

        if (Scenenum == 2 && scene2play == false)
        {
            levelMusicPlay();
            scene2play = true;
        }

        if (Scenenum == 3 && scene3play == false)
        {
            levelMusicPlay();
            scene3play = true;
        }

        if (Scenenum == 4 && scene4play == false)
        {
            levelMusicPlay();
            scene4play = true;
        }


    }
}
