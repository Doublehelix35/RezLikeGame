using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 5;
    int CurHealth;

    public int DamageValue = -1;


    void Start()
    {
        CurHealth = MaxHealth;
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Bee")
        {
            // Lose health
            ChangeHealth(DamageValue);

            // Destroy bee
            Destroy(col.gameObject);
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
    }
}
