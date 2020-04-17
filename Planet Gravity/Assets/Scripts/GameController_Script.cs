using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController_Script : MonoBehaviour
{
    // Player
    [HideInInspector] public bool IsPlayerDead = false;

    // Planet Generation
    public int PlanetNumber = 0;
    public GameObject[] Planets;

    private void Update()
    {
        Planets = GameObject.FindGameObjectsWithTag("TUP");
        Testing();
    }

    void Testing()
    {
        if (Input.GetKey("r"))
        {
            SceneManager.LoadScene("PlayScene");
        }
    }
}
