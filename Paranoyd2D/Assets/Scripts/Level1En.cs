using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1En : MonoBehaviour
{
    public float enemyProjectileSpeed = 6f;
    public float enemyProjectileMaxSpeed = 12f;
    public Transform enemy;
    int currentSceneIndex;
    public GameObject nemico2;
    public bool finale = false;
    public GameObject effect;
    private Shake shake;
    private Shake explosionShake;
    public GameObject ball;
    private float timer = 0.75f;
    public GameObject panelEndLevel;

    //Spawn this object
    public GameObject bullet;

    public float maxTime = 5;
    public float minTime = 2;

    //current time
    private float time;

    //The time to spawn the object
    private float spawnTime;

    

    void Start()
    {
        explosionShake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        SetRandomTime();
        time = 0;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    void FixedUpdate()
    {
        //Counts up
        time += Time.deltaTime;

        //Check if its the right time to spawn the object
        if (time >= spawnTime)
        {
            timer = timer - Time.deltaTime;

            ball.SetActive(true);

            if(timer <= 0)
            {
                ball.SetActive(false);
                SpawnBullet();
                timer = 0.75f;
            }

            SetRandomTime();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            
            Instantiate(effect, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Esplosione");
            explosionShake.ExplosionShake();
            Debug.Log("cretino");
            gameObject.SetActive(false);

            if (nemico2 != null)
            {
                nemico2.SetActive(true);
            }
            if(finale)
            {
                shake.CamShake();
                Instantiate(effect, transform.position, Quaternion.identity);

                panelEndLevel.SetActive(true);
                
            }

            
        }
    }


    //Spawns the object and resets the time
    void SpawnBullet()
    {
        time = 0;
        var projectile = Instantiate(bullet, enemy.position, enemy.rotation);
        projectile.GetComponent<Rigidbody2D>().velocity = projectile.transform.up * enemyProjectileSpeed;
        projectile.GetComponent<Bullet>().minSpeed = enemyProjectileSpeed;
        projectile.GetComponent<Bullet>().maxSpeed = enemyProjectileMaxSpeed;
    }

    //Sets the random time between minTime and maxTime
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }
    
}
