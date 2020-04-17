﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController_Script : MonoBehaviour
{
    // Movement
    public Joystick MovementJoystick;
    [HideInInspector] public float Speed = 10f;
    private Rigidbody2D rb;
    private Vector3 Direction;

    // Movement rotation
    public GameObject Pivot;
    public Quaternion LastPivot;

    // Slow motion
    private float SlowMotion = 0.1f;
    private float NormalMotion = 1f;

    // Death
    public GameObject ExplosionParticle;

    // Sounds
    public GameObject ExplosionS;
    public GameObject FuelS;

    // References
    GameController_Script GameScript;
    CameraShakingController_Script CamShakeScript;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        GameScript = FindObjectOfType<GameController_Script>();
        CamShakeScript = FindObjectOfType<CameraShakingController_Script>();
    }

    private void FixedUpdate()
    {
        Movement();
        MovementRotation();
    }

    void Movement()
    {
        if (GameScript.IsPlayerDead == false)
        {
            Direction = Vector3.up * -MovementJoystick.Vertical + Vector3.right * -MovementJoystick.Horizontal;
            rb.AddForce(Direction * Speed, ForceMode2D.Force);
        }
    }

    void MovementRotation()
    {
        float Direction = Mathf.Atan2(-MovementJoystick.Horizontal, -MovementJoystick.Vertical);
        float Still = MovementJoystick.Horizontal * MovementJoystick.Vertical;

        if (Still != 0)
        {
            Pivot.transform.rotation = Quaternion.Euler(0f, 0f, -Direction * Mathf.Rad2Deg);
            LastPivot = Quaternion.Euler(0f, 0f, -Direction * Mathf.Rad2Deg);
        }
        else
        {
            Pivot.transform.rotation = LastPivot;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fuel"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(FuelSlowMotion());
            rb.AddForce(Direction * 10000f, ForceMode2D.Force);
            StartCoroutine(PlaySound(FuelS));
            CamShakeScript.shakeDuration = .05f;
        }

        if (collision.gameObject.CompareTag("Planet"))
        {
            CamShakeScript.shakeDuration = .4f;
            StartCoroutine(PlaySound(ExplosionS));
            Instantiate(ExplosionParticle, transform.position, Quaternion.identity);
            PlayerDeathCollision();
        }

        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(collision.gameObject);
            CamShakeScript.shakeDuration = .3f;
            Instantiate(ExplosionParticle, transform.position, Quaternion.identity);
            StartCoroutine(PlaySound(ExplosionS));
            PlayerDeathCollision();
        }

        if (collision.gameObject.CompareTag("BarrierL"))
        {
            transform.position = new Vector3 (15.92f, transform.position.y, 0f);
        }

        if (collision.gameObject.CompareTag("BarrierR"))
        {
            transform.position = new Vector3(-15.92f, transform.position.y, 0f);
        }
    }

    void PlayerDeathCollision()
    {
        GameScript.IsPlayerDead = true;
        MovementJoystick.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }

    IEnumerator FuelSlowMotion()
    {
        Time.timeScale = SlowMotion;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        yield return new WaitForSeconds(.01f);

        Time.timeScale = NormalMotion;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    IEnumerator PlaySound(GameObject clip)
    {
        GameObject Audio = Instantiate(clip, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3);
        Destroy(Audio);
    }
}
