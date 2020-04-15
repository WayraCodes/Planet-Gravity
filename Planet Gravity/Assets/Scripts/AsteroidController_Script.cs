using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController_Script : MonoBehaviour
{
    private float Speed = .2f;
    private Rigidbody2D rb;
    private int Rand1;
    private int Rand2;
    private Vector3 Direction;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Rand1 = Random.Range(-1, 2);
        Rand2 = Random.Range(-1, 2);
        Debug.Log(Rand1 + " " + Rand2);
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        if (Rand1 == 0 && Rand2 == 0)
        {
            Rand1 = 1;
        }

        Direction = Vector3.up * Rand1 + Vector3.right * Rand2;
        rb.velocity = Direction * Speed;
    }
}
