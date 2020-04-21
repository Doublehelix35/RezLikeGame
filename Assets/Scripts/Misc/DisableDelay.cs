using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDelay : MonoBehaviour
{
    public float DelayTime = 1f;
    public bool IsDestroyable = false;

    internal bool IsDisabled = false;

    float curTime = 0f;

    void Update()
    {
        if (!IsDisabled)
        {
            curTime += Time.deltaTime;

            if (curTime > DelayTime)
            {
                if (IsDestroyable)
                {
                    Destroy(gameObject);
                }
                else
                {
                    gameObject.SetActive(false);
                    IsDisabled = true;
                }

                // Reset current time
                curTime = 0;
            }
        }

        // Check if reactivated
        if (IsDisabled && gameObject.activeInHierarchy)
        {
            IsDisabled = false;
        }
        
    }
}
