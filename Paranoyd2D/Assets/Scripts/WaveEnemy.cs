using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyProjectileSpeed = 2f;
    public Transform enemy;
    public Transform myPosition;

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
        SetRandomTime();
        time = minTime;
    }

    void FixedUpdate()
    {
        //Counts up
        time += Time.deltaTime;

        //Check if its the right time to spawn the object
        if (time >= spawnTime)
        {
            SpawnBullet();
            SetRandomTime();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Die();
        }
    }

    private void Die()
    {
        GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<Spawner>().spawnPoisitions.Add(myPosition);
        Destroy(gameObject);
    }


    //Spawns the object and resets the time
    void SpawnBullet()
    {
        time = 0;
        var projectile = Instantiate(bullet, enemy.position, enemy.rotation);
        projectile.GetComponent<Rigidbody2D>().velocity = projectile.transform.up * enemyProjectileSpeed;
    }

    //Sets the random time between minTime and maxTime
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }
    
}
