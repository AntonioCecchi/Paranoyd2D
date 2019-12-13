using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnemy : MonoBehaviour
{
    public float enemyProjectileSpeed = 6f;
    public float enemyProjectileMaxSpeed = 12f;
    public Transform enemy;
    int currentSceneIndex;
    private Shake shake;
    public GameObject effect;
    private Shake explosionShake;
    public GameObject ball;
    private float timer = 0.75f;

    //Spawn this object
    public GameObject bullet;

    public float maxTime = 2;
    public float minTime = 0.5f;

    //current time
    private float time;

    //The time to spawn the object
    private float spawnTime;

    

    void Start()
    {
        explosionShake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        SetRandomTime();
        time = minTime;
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

            FindObjectOfType<AudioManager>().Play("StaPerSparare");

            ball.SetActive(true);
            

            if (timer <= 0)
            {
                ball.SetActive(false);
                FindObjectOfType<AudioManager>().Play("Shoot");
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
            //  Instantiate(puntoEsclamativo, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
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
