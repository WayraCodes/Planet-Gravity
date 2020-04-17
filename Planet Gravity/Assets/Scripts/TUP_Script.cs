using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUP_Script : MonoBehaviour
{
    public GameObject TUP;

    // References
    GameController_Script GameScript;

    private void Start()
    {
        GameScript = FindObjectOfType<GameController_Script>();
        GameScript.PlanetNumber += 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(TUP, transform.position + new Vector3 (0, 96, 0), Quaternion.identity);
            if (GameScript.PlanetNumber > 2)
            {
                foreach (GameObject Planet in GameScript.Planets)
                {
                    Debug.Log("Hedwe");

                    if (Planet.transform.position.y < transform.position.y - 1f)
                    {
                        Destroy(Planet.gameObject);
                    }
                }
            }
        }
    }
}
