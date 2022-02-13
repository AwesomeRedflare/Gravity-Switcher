using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject transition;
    public GameObject pauseMenu;

    private bool isPaused;

    private void Start()
    {
        transition.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && isPaused == false)
        {
            FindObjectOfType<AudioManager>().Play("Button");

            LevelSelectClose();
            isPaused = true;
        }
    }

    void LevelSelectClose()
    {
        if (pauseMenu.activeSelf == true)
        {
            pauseMenu.GetComponent<Animator>().SetTrigger("Close");
        }

        pauseMenu.SetActive(true);
    }

    public void LevelSelectOpen()
    {
        FindObjectOfType<AudioManager>().Play("Button");

        pauseMenu.GetComponent<Animator>().SetTrigger("Open");
        isPaused = false;
    }

    public IEnumerator Death()
    {
        CloseTransition();

        yield return new WaitForSeconds(.4f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public IEnumerator Goal()
    {
        CloseTransition();

        yield return new WaitForSeconds(.4f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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

    public void RetryButton()
    {
        FindObjectOfType<AudioManager>().Play("Button");

        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Death();
    }
}
