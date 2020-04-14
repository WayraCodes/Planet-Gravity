using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthController_Script : MonoBehaviour
{
    private GameObject Player;
    ArrayList AllObjects = new ArrayList();
    private bool PlayerInSight = false;

    private void Start()
    {
        AllObjects.Add (GameObject.FindGameObjectsWithTag("Asteroid"));
        Player = GameObject.FindGameObjectWithTag("Player");
        AllObjects.Add(Player);
        
    }

    // Formula: F = G m1 m2 / r^2

    private void FixedUpdate()
    {
        if (PlayerInSight)
        {
            GravitationalPull(AllObject);
        }
    }

    void GravitationalPull(GameObject t)
    {
        Vector3 Diference = transform.position - t.gameObject.transform.position;
        float Distance = Diference.magnitude;
        Vector3 GravityDireccion = Diference.normalized;
        float Gravity = 9.8f * (this.transform.localScale.x * t.transform.localScale.x * 20) / (Distance * Distance);
        Vector3 GravityVector = (GravityDireccion * Gravity);
        t.gameObject.transform.GetComponent<Rigidbody2D>().AddForce(GravityVector, ForceMode2D.Force);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInSight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInSight = false;
        }
    }
}
