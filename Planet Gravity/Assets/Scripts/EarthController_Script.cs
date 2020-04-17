using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthController_Script : MonoBehaviour
{
    // Gravity Pull
    private GameObject Player;
    private GameObject[] AllObjects;
    private bool PlayerInSight = false;
    private GameObject AsteroidAffected;
    private float OriginalPlayerSpeed;

    // References
    GameController_Script GameScript;
    PlayerController_Script PlayerScript;

    private void Start()
    {
        AllObjects = GameObject.FindGameObjectsWithTag("Asteroid");
        Player = GameObject.FindGameObjectWithTag("Player");
        GameScript = FindObjectOfType<GameController_Script>();
        PlayerScript = FindObjectOfType<PlayerController_Script>();
        OriginalPlayerSpeed = PlayerScript.Speed;
    }

    // Formula: F = G m1 m2 / r^2

    private void Update()
    {
        AllObjects = GameObject.FindGameObjectsWithTag("Asteroid");
    }

    private void FixedUpdate()
    {
        if (PlayerInSight)
        {
            if (GameScript.IsPlayerDead == false)
            {
                GravitationalPull(Player, 4f);
            }
        }

        foreach (GameObject Asteroid in AllObjects)
        {
            if (Asteroid == AsteroidAffected)
            {
                GravitationalPull(Asteroid, 30f);
            }
        }
    }

    void GravitationalPull(GameObject t, float multiplier)
    {
        
            if (GameScript.IsPlayerDead == false)
            {
                Vector3 Diference = transform.position - t.gameObject.transform.position;
                float Distance = Diference.magnitude;
                Vector3 GravityDireccion = Diference.normalized;
                float Gravity = 25f * (this.transform.localScale.x * t.transform.localScale.x * multiplier) / (Distance * Distance);
                Vector3 GravityVector = (GravityDireccion * Gravity);
                t.gameObject.transform.GetComponent<Rigidbody2D>().AddForce(GravityVector, ForceMode2D.Force);
            }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInSight = true;
            PlayerScript.Speed = 14f;
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
            PlayerScript.Speed = OriginalPlayerSpeed;
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
