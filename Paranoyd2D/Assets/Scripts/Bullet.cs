using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject player;
    private SpriteRenderer p_render;
    private Animator p_animator;
    public GameObject deathPanel;
    private float timer = 1.5f;

    private Shake shake;

    public GameObject trailMaxSpeed;
    private Rigidbody2D rb;
    public float minSpeed;
    public float maxSpeed;
    private float multiplier;
    private float index;
    private bool collisionIsDone = false;

    public float tempoFlicker;


    private void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (rb.velocity.magnitude > 9)
        {
            trailMaxSpeed.SetActive(true);
        }
        else
        {
            trailMaxSpeed.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("UrtoScudo");

            if (!collisionIsDone)
            {
                p_animator = player.GetComponent<Animator>();

                shake.CamShake();

                index = Mathf.Abs(other.gameObject.GetComponent<Player>().speed) / other.gameObject.GetComponent<Player>().maxSpeed;
                multiplier = Mathf.Lerp(minSpeed, maxSpeed, index);
                gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity.normalized * multiplier;
                collisionIsDone = true;

                p_animator.SetTrigger("HIT");

                //StartCoroutine(Flicker(tempoFlicker));
            }
        }

        if (other.gameObject.tag == "Heart")
        {
            player = GameObject.FindWithTag("Player");

            FindObjectOfType<AudioManager>().Play("Esplosione");
            Destroy(player);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Wall")
        {
            FindObjectOfType<AudioManager>().Play("UrtoProiettile");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("UrtoScudo");

            if (!collisionIsDone)
            {
                shake.CamShake();

                index = Mathf.Abs(collision.gameObject.GetComponent<Player>().speed) / collision.gameObject.GetComponent<Player>().maxSpeed;
                multiplier = Mathf.Lerp(minSpeed, maxSpeed, index);
                gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity.normalized * multiplier;
                collisionIsDone = true;
            }
        }

        if (collision.gameObject.tag == "Heart")
        {
            FindObjectOfType<AudioManager>().Play("Esplosione");

            Destroy(player);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Wall")
        {
            FindObjectOfType<AudioManager>().Play("UrtoProiettile");
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collisionIsDone)
        {
            collisionIsDone = false;
        }
    }

    //IEnumerator Flicker(float intervallo)
    //{
    //    p_render.color = new Color (p_render.color.r, p_render.color.g, p_render.color.b, 0.5f);
    //    yield return new WaitForSeconds(intervallo);
    //    p_render.color = new Color(p_render.color.r, p_render.color.g, p_render.color.b, 1f);

    //}
}