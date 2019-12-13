using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float acceleration;
    public float maxSpeed;
    [Range(0f,1f)]
    public float friction;
    

    private void Update()
    {
        if (Input.GetMouseButton(0) && Input.GetMouseButton(1)) //se premo entrambi non fa nulla
        {
            Debug.Log("EHH VOLEVII");
        }
        else
        if (Input.GetMouseButton(0))
        {
            FindObjectOfType<AudioManager>().Play("RotazionePiattaforma");

            if (speed < 0)
            {
                speed = speed + (3f* acceleration) * Time.deltaTime; //se premo tasto sx o dx accelera
                if (speed >= maxSpeed) //mantengo la velocità stabile
                {
                    speed = maxSpeed;
                }
                transform.Rotate(0, 0, speed);
            }
            else
            {
                speed = speed + acceleration * Time.deltaTime; //se premo tasto sx o dx accelera
                if (speed >= maxSpeed) //mantengo la velocità stabile
                {
                    speed = maxSpeed;
                }
                transform.Rotate(0, 0, speed);
            }
        }
        else
        if (Input.GetMouseButton(1))
        {
            FindObjectOfType<AudioManager>().Play("RotazionePiattaforma");

            if (speed > 0)
            {
                speed = speed - (3f * acceleration) * Time.deltaTime; //se premo tasto sx o dx accelera
                if (speed <= -maxSpeed) //mantengo la velocità stabile
                {
                    speed = -maxSpeed;
                }
                transform.Rotate(0, 0, speed);
            }
            else
            {
                speed = speed - acceleration * Time.deltaTime; //se premo tasto sx o dx accelera
                if (speed <= -maxSpeed) //mantengo la velocità stabile
                {
                    speed = -maxSpeed;
                }
                transform.Rotate(0, 0, speed);
            }
        }

        if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            speed = speed * friction; //se non tocco nulla va a 0 e resta a 0

            if (speed > 0)
            {
                if (speed < 0.1f)
                {
                    speed = 0;
                }
                transform.Rotate(0, 0, speed);
            }
            else if (speed < 0)
            {
                if (speed > 0.1f)
                {
                    speed = 0;
                }
                transform.Rotate(0, 0, speed);
            }
        }
        

        //    if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        //    {
        //    }
        //    else
        //    if (Input.GetMouseButton(0))
        //    {
        //        transform.Rotate(0, 0, 1 * speed);

        //        if (speed >= maxSpeed)
        //        {
        //            speed = maxSpeed;
        //        }
        //        else
        //        {
        //            speed += acceleration;
        //        }
        //    }

        //    if (Input.GetMouseButton(1))
        //    {
        //        transform.Rotate(0, 0, -1 * speed);

        //        if (speed >= maxSpeed)
        //        {
        //            speed = maxSpeed;
        //        }
        //        else
        //        {
        //            speed += acceleration;
        //        }
        //    }
        //    else if (speed <= acceleration)
        //    {
        //        speed = 0;
        //    }
        
        //}
        
    }
}

