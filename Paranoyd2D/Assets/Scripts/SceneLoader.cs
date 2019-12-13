using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private int currentSceneIndex;
    private float timer = 0.75f;
    public GameObject endLevelPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(currentSceneIndex == 1)
        {

        }
        else
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            timer = timer - Time.deltaTime;
            
            if(timer <= 0)
            {
                FindObjectOfType<AudioManager>().Play("FineLivello");
                endLevelPanel.SetActive(true);
                Time.timeScale = 0f;
                timer = 0.75f;
            }

        }

    }

    public void NextScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    

}
