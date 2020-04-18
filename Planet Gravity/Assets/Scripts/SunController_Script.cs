using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController_Script : MonoBehaviour
{
    // Movement
    private float Speed = 5f;
    private Rigidbody2D rb;
    public Joystick MovementJoystick;

    // References
    GameController_Script GameScript;
    PlayerController_Script PlayerScript;
    private GameObject Player;
    CameraShakingController_Script CamShakeScript;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameScript = FindObjectOfType<GameController_Script>();
        Player = GameObject.FindGameObjectWithTag("Player");
        CamShakeScript = FindObjectOfType<CameraShakingController_Script>();
    }

    private void FixedUpdate()
    {
        if (GameScript.IsPlayerDead == false)
        {
            rb.velocity = Vector2.up * Speed;
        }
        else
        {
            rb.velocity = new Vector3(0,0,0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CamShakeScript.shakeDuration = .4f;
            PlayerDeathCollision();
        }
    }

    void PlayerDeathCollision()
    {
        GameScript.IsPlayerDead = true;
        MovementJoystick.gameObject.SetActive(false);
        Player.gameObject.SetActive(false);
    }
}
