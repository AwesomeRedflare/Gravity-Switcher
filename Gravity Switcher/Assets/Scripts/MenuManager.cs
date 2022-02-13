using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject transition;
    public GameObject levelSelectPanel;

    private void Start()
    {
        transition.SetActive(true);
    }

    void CloseTransition()
    {
        transition.GetComponent<Animator>().SetTrigger("Close");
    }

    void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartButton()
    {
        FindObjectOfType<AudioManager>().Play("Button");

        CloseTransition();

        Timer.currentTime = 0;
        Timer.stopWatchActive = true;

        Invoke("StartGame", .4f);
    }

    public void LevelSelectClose()
    {
        FindObjectOfType<AudioManager>().Play("Button");

        if (levelSelectPanel.activeSelf == true)
        {
            levelSelectPanel.GetComponent<Animator>().SetTrigger("Close");
        }

        levelSelectPanel.SetActive(true);
    }

    public void LevelSelectOpen()
    {
        FindObjectOfType<AudioManager>().Play("Button");

        levelSelectPanel.GetComponent<Animator>().SetTrigger("Open");
    }
    
    public void LevelButton(int l)
    {
        FindObjectOfType<AudioManager>().Play("Button");

        StartCoroutine("LevelSelector", l);

        Timer.currentTime = 0;
        Timer.stopWatchActive = false;
    }

    IEnumerator LevelSelector(int level)
    {
        CloseTransition();

        yield return new WaitForSeconds(.4f);

        SceneManager.LoadScene(level);
    }
    
}
