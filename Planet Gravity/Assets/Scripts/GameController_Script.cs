using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController_Script : MonoBehaviour
{
    [HideInInspector] public bool IsPlayerDead = false;

    private void Update()
    {
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
