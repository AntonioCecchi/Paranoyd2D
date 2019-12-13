using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{

    private GameObject player;
    private Shake shake;
    private GameObject deathPanel;
    public GameObject effect;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        deathPanel = GameObject.FindGameObjectWithTag("DeathPanel");
    }

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            FindObjectOfType<AudioManager>().Play("Esplosione"); 
            Destroy(player);
            Instantiate(effect,transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }

}
