using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour {

    public void PauseGame()
    {
        Time.timeScale = 0f;
        //pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;

    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        FindObjectOfType<GameManager>().Reset();
    }

    public void quitMain()
    {
        FindObjectOfType<GameManager>().Reset();

        SceneManager.LoadScene(0);
    }
}
