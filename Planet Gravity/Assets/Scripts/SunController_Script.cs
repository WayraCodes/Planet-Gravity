using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController_Script : MonoBehaviour
{
    private float Speed = 2f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.velocity = Vector2.up * Speed;
    }
}
