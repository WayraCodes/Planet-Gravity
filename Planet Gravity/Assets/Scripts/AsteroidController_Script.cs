using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController_Script : MonoBehaviour
{
    // Movement
    private float Speed = .2f;
    private Rigidbody2D rb;

    // Random Direction
    private int Rand1;
    private int Rand2;
    private Vector3 Direction;
    public bool IsAlive = true;

    // Rotation
    private int RandRotation;

    // References
    CameraShakingController_Script CamShakeScript;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Rand1 = Random.Range(-1, 2);
        Rand2 = Random.Range(-1, 2);
        CamShakeScript = FindObjectOfType<CameraShakingController_Script>();
        RandRotation = Random.Range(2, 90);
    }

    private void FixedUpdate()
    {
        Movement();
        Rotation();
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

    void Rotation()
    {
        this.transform.Rotate(new Vector3(0, 0, RandRotation) * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Planet"))
        {
            CamShakeScript.shakeDuration = .05f;
            this.gameObject.SetActive(false);
        }
    }
}
