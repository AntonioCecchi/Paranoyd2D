using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerEnemy : MonoBehaviour
{
    public float enemyTimer = 12f;
    public float timerlv1;
    public float timerlv2;
    public float timerlv3;
    public float timerlv4;
    public float timerlv5;
    public float timerlv6;
    public float timerlv7;

    public GameObject enemy;
    private int currentSceneIndex;
    public GameObject respawnEff;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        respawnEff.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {

        if (currentSceneIndex == 0)
        {
            Debug.Log("ciao");
        }
        else
        if (!enemy.activeSelf)
        {
            enemyTimer = enemyTimer - Time.deltaTime;
        }

        if (enemyTimer <= 2)
        {
            respawnEff.SetActive(true);
        }

        if (enemyTimer <= 0)
        {
            respawnEff.SetActive(false);
            enemy.SetActive(true);

            if (currentSceneIndex == 2)
            {
                enemyTimer = timerlv2;
            }
            else
            if (currentSceneIndex == 3)
            {
                enemyTimer = timerlv3;
            }
            else
            if (currentSceneIndex == 4)
            {
                enemyTimer = timerlv4;
            }
            else
            if (currentSceneIndex == 5)
            {
                enemyTimer = timerlv5;
            }
            else
            if (currentSceneIndex == 6)
            {
                enemyTimer = timerlv6;
            }
            else
            if (currentSceneIndex == 7)
            {
                enemyTimer = timerlv7;
            }
        }

    }

}
