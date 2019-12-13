using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private GameObject deathPanel;
    private float timer = 0.75f;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        deathPanel = GameObject.FindGameObjectWithTag("DeathPanel");
        deathPanel.SetActive(false);
    }

   

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            timer = timer - Time.deltaTime;

            if(timer <= 0)
            {
                Time.timeScale = 0f;
                deathPanel.SetActive(true);
                timer = 0.75f;
            }

        }
    }
}
