using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BufferZone_Script : MonoBehaviour
{
    private bool PointsClaimed = false;
    GameController_Script GameScript;
    public bool IsOuterLayer;

    private void Start()
    {
        GameScript = FindObjectOfType<GameController_Script>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!PointsClaimed)
            {
                switch (IsOuterLayer)
                {
                    case true:
                        GameScript.Score.gameObject.SetActive(false);
                        GameScript.Score.gameObject.SetActive(true);
                        GameScript.ScoreInt += 1;
                        break;
                    case false:
                        GameScript.Score.gameObject.SetActive(false);
                        GameScript.Score.gameObject.SetActive(true);
                        GameScript.ScoreInt += 1;
                        break;
                }

                PointsClaimed = true;
            }
        }
    }
}
