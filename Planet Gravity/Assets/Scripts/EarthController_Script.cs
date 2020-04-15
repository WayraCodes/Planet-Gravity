using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthController_Script : MonoBehaviour
{
    private GameObject Player;
    private GameObject[] AllObjects;
    private bool PlayerInSight = false;
    private GameObject AsteroidAffected;

    private void Start()
    {
        AllObjects = GameObject.FindGameObjectsWithTag("Asteroid");
        Player = GameObject.FindGameObjectWithTag("Player");        
    }

    // Formula: F = G m1 m2 / r^2

    private void FixedUpdate()
    {
        if (PlayerInSight)
        {
            GravitationalPull(Player);
        }

        foreach(GameObject Asteroid in AllObjects)
        {
            if (Asteroid == AsteroidAffected)
            {
                GravitationalPull(Asteroid);
            }
        }
    }

    void GravitationalPull(GameObject t)
    {
        Vector3 Diference = transform.position - t.gameObject.transform.position;
        float Distance = Diference.magnitude;
        Vector3 GravityDireccion = Diference.normalized;
        float Gravity = 9.8f * (this.transform.localScale.x * t.transform.localScale.x * 5) / (Distance * Distance);
        Vector3 GravityVector = (GravityDireccion * Gravity);
        t.gameObject.transform.GetComponent<Rigidbody2D>().AddForce(GravityVector, ForceMode2D.Force);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInSight = true;
        }

        if (collision.CompareTag("Asteroid"))
        {
            foreach (GameObject Asteroid in AllObjects)
            {
                if (Asteroid == collision.gameObject)
                {
                    AsteroidAffected = collision.gameObject;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInSight = false;
        }

        if (collision.CompareTag("Asteroid"))
        {
            if (AsteroidAffected == collision.gameObject)
            {
                AsteroidAffected = null;
            }
        }
    }
}
