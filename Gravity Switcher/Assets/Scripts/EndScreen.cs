using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class EndScreen : MonoBehaviour
{
    public GameObject transition;

    public Text finalTimeText;

    public GameObject noTimeText;

    private void Start()
    {
        transition.SetActive(true);

        Timer.stopWatchActive = false;

        if(Timer.currentTime > 0)
        {
            TimeSpan time = TimeSpan.FromSeconds(Timer.currentTime);

            finalTimeText.gameObject.SetActive(true);
            finalTimeText.text = "Your time was: " + time.ToString(@"mm\:ss\:ff");

            //best time: 37.84 seconds
        }
        else
        {
            noTimeText.SetActive(true);
        }
    }

    public void MainMenuButton()
    {
        FindObjectOfType<AudioManager>().Play("Button");

        CloseTransition();

        Invoke("GoToMainMenu", .4f);
    }

    void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    void CloseTransition()
    {
        transition.GetComponent<Animator>().SetTrigger("Close");
    }
}
