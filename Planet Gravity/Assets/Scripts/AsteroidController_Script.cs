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

    // References
    CameraShakingController_Script CamShakeScript;
    GameController_Script GameScript;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Rand1 = Random.Range(-1, 2);
        Rand2 = Random.Range(-1, 2);
        Debug.Log(Rand1 + " " + Rand2);
        CamShakeScript = FindObjectOfType<CameraShakingController_Script>();
        GameScript = FindObjectOfType<GameController_Script>();
        GameScript.AsteroidNumber += 1;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Planet"))
        {
            CamShakeScript.shakeDuration = .05f;
            this.gameObject.SetActive(false);
        }
    }
}
