using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineExample : MonoBehaviour
{
    void Start()
    {
        Countdown();
    }

    void Countdown()
    {
        StartCoroutine(CountDownTimer(10.0f));
    }

    IEnumerator CountDownTimer(float maxTime)
    {
       while(maxTime > 0)
        {
            Debug.Log(maxTime);
            yield return new WaitForSeconds(1);
            maxTime--;
        }
        Debug.Log("blastoff");
    }
}


