using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Color hpstartcolour;
    public Color hpoof;
    public Color hphurt;
    public Color hpdying;

    public GameObject segmentholder;

    //public Slider SliderRef;
    LockOnV2 LockOnV2Ref; 

    public int MaxHealth = 8;
    int CurHealth;

    public int DamageValue = -1;


    void Start()
    {
        // Init health and UI
        CurHealth = MaxHealth;

        /*SliderRef.minValue = 0f;
        SliderRef.maxValue = MaxHealth;
        SliderRef.value = MaxHealth;*/

        // Init ref
        LockOnV2Ref = Camera.main.gameObject.GetComponent<LockOnV2>();
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Bee")
        {
            // Lose health
            ChangeHealth(DamageValue);

            // Disable bee
            col.gameObject.GetComponent<LockOnV1>().locked = false;
            col.gameObject.SetActive(false);
        }
        else if(col.gameObject.tag == "Enemy")
        {
            // Lose health
            ChangeHealth(DamageValue);
        }
    }

    void ChangeHealth(int valueToChangeBy)
    {

        // Add value to change by to current health
        CurHealth += valueToChangeBy;

        // Update UI
        //SliderRef.value = CurHealth;

        if (CurHealth >= 0)
        {
            segmentholder.transform.GetChild(CurHealth).gameObject.SetActive(false);

            switch (CurHealth)
            {
                case 6:
                    colourchange(hpoof);
                    break;

                case 4:
                    colourchange(hphurt);
                    break;

                case 2:
                    colourchange(hpdying);
                    break;
            }
        }
        else if (CurHealth <= 0)
        {
            die();
        }
    }

    void colourchange(Color colourtarget)
    {
        Debug.Log("running");
        for (int i = 0; i < segmentholder.transform.childCount; i++)
        {
            segmentholder.transform.GetChild(i).GetComponent<Image>().color = colourtarget;
        }
    }

    void die()
    {
        StartCoroutine(PlayerDie());
    }

    IEnumerator PlayerDie()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameOver");
    }

}
