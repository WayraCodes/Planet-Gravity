using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController_Script : MonoBehaviour
{
    private GameController_Script GameScript;

    private void Start()
    {
        GameScript = FindObjectOfType<GameController_Script>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameScript.ScoreInt += 3;
        }
    }
}
