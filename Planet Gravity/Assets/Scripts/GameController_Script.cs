using System.Collections;
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
    private bool HasFinished = true;

    // References
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        Planets = GameObject.FindGameObjectsWithTag("TUP");
        Testing(); AsteroidSpawning();
    }

    void AsteroidSpawning()
    {
        while (AsteroidNumber < PlanetNumber * 2)
        {
            AsteroidNumber += 1;
            int PosX = Random.Range(-15, 16);
            float PosY = Random.Range(Player.transform.position.y + 15.3f, Player.transform.position.y + 22f);
            Vector3 FinalTransform = new Vector3(PosX, PosY, 0f);
            Instantiate(Asteroid, FinalTransform, Quaternion.identity);
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
