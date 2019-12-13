using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class Barrier : MonoBehaviour
{
    public Sprite barrier;
    public Sprite brokenBarrier;



    private void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = barrier;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            if(this.gameObject.GetComponent<SpriteRenderer>().sprite == barrier)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = brokenBarrier;
            }
            else if(this.gameObject.GetComponent<SpriteRenderer>().sprite == brokenBarrier)
            {
                Destroy(gameObject);
            }
        }

        
    }
}
