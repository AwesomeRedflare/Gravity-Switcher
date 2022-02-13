using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public static bool stopWatchActive = true;

    public static float currentTime;

    public Text timerText;

    private void Start()
    {
        if (stopWatchActive == false)
        {
            timerText.gameObject.SetActive(false);
        }
        else
        {
            timerText.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if(stopWatchActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }

        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timerText.text = time.ToString(@"mm\:ss\:ff");
    }
}
