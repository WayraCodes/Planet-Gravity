﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 0, -0.75, 0
// 0, -16.04, 0
// -----------
// 0, 15.30, 0

// -15, 15 = x
// player.pos + 15.3, player.pos + 22 = y
// 0 = z

public class GameController_Script : MonoBehaviour
{
    // Player
    [HideInInspector] public bool IsPlayerDead = false;

    // Planet Generation
    [HideInInspector] public int PlanetNumber = 0;
    public GameObject[] Planets;

    // Asteroid Generation
    public GameObject Asteroid;
    [HideInInspector] public int AsteroidNumber;
    private GameObject[] Asteroids;
    private bool HasFinished = true;
    private int NumberToSpawn = 2;
    private bool Started = false;
    private bool Started2 = false;

    // DeathScreen
    public GameObject DeathScreen;

    // References
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
    }

    private void Update()
    {
        Planets = GameObject.FindGameObjectsWithTag("TUP");
        Testing();
        if (IsPlayerDead == false)
        {
            AsteroidSpawning();
            if (!Started)
            {
                StartCoroutine(NumIncrement());
            }
        }
        TriggerDeathScreen();
    }

    // Death Screen
    void TriggerDeathScreen()
    {
        if (IsPlayerDead)
        {
            DeathScreen.gameObject.SetActive(true);
        }
    }

    // Asteroids
    void AsteroidSpawning()
    {
        while (AsteroidNumber < NumberToSpawn)
        {
            if (IsPlayerDead == false)
            {
                AsteroidNumber += 1;
                int PosX = Random.Range(-15, 16);
                float PosY = Random.Range(Player.transform.position.y + 15.3f, Player.transform.position.y + 22f);
                Vector3 FinalTransform = new Vector3(PosX, PosY, 0f);
                Instantiate(Asteroid, FinalTransform, Quaternion.identity);
            }
        }

        if (AsteroidNumber == NumberToSpawn)
        {
            if (Started2 == false)
            {
                StartCoroutine(WaitNum());
            }
        }

        foreach (GameObject Astro in Asteroids)
        {
            if (Astro.transform.position.y < Player.transform.position.y - 11f)
            {
                Destroy(Astro.gameObject);
            }
        }
    }

    IEnumerator WaitNum ()
    {
        Started2 = true;
        yield return new WaitForSeconds(10);
        AsteroidNumber = 0;
        Started2 = false;
    }
    IEnumerator NumIncrement()
    {
        while (true)
        {
            Started = true;
            yield return new WaitForSeconds(5);
            NumberToSpawn += 1;
            Started = false;
        }
    }

    void Testing()
    {
        if (Input.GetKey("r"))
        {
            SceneManager.LoadScene("PlayScene");
        }
    }
}
