using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI count;
    [SerializeField] private float seconds = 15;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDownTimer());
    }

    // Update is called once per frame
    void Update()
    {
        Tick();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isPaused)
            {
                isPaused = false;
                StartCoroutine(CountDownTimer());
            } else
            {
                isPaused = true;
                StopAllCoroutines();
            }
        }

    }

    IEnumerator CountDownTimer()
    {
        while (seconds > 0)
        {
            Debug.Log(seconds);
            yield return new WaitForSeconds(1);
            seconds--;
        }
        Debug.Log("Gameover");
    }

    private void Tick()
    {
        count.text = seconds.ToString();
    }
}
