using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public float lowPitchRange = .95f; //Lowest pitch a sfx will be
    public float highPitchRange = 1.05f; //Highest pitch a sfx will be

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



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }
}
