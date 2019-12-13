using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private int currentSceneIndex;
    public GameObject pausePanel;
    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Time.timeScale = 1f;
                pausePanel.SetActive(false);
                isPaused = false;
            }
            else if(isPaused == false)
            {
                Time.timeScale = 0f;
                pausePanel.SetActive(true);
                isPaused = true;
            }
        }
    }

    public void RetryLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TITLE");
    }

}
