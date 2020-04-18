using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthController_Script : MonoBehaviour
{
    // Gravity Pull
    private GameObject Player;
    private GameObject[] AllObjects;
    private bool PlayerInSight = false;
    private GameObject AsteroidAffected;
    private float OriginalPlayerSpeed;

    // Orb Spawner
    public GameObject R;
    public GameObject L;
    public GameObject T;
    public GameObject B;
    private int SelectionNumber;

    // Planet Selection
    public SpriteRenderer CenterSprite;
    public Sprite[] Planets;
    private int RandomPlanet;

    // References
    GameController_Script GameScript;
    PlayerController_Script PlayerScript;
    public GameObject Orb;

    private void Start()
    {
        SelectionNumber = Random.Range(1, 6);
        AllObjects = GameObject.FindGameObjectsWithTag("Asteroid");
        Player = GameObject.FindGameObjectWithTag("Player");
        GameScript = FindObjectOfType<GameController_Script>();
        PlayerScript = FindObjectOfType<PlayerController_Script>();
        OriginalPlayerSpeed = PlayerScript.Speed;
        OrbSpawner();
        RandomPlanet = Random.Range(1, Planets.Length);
        CenterSprite.sprite = Planets[RandomPlanet];
     }

    private void Update()
    {
        AllObjects = GameObject.FindGameObjectsWithTag("Asteroid");
    }

    private void FixedUpdate()
    {
        if (PlayerInSight)
        {
            if (GameScript.IsPlayerDead == false)
            {
                GravitationalPull(Player, 2f);
            }
        }

        foreach (GameObject Asteroid in AllObjects)
        {
            if (Asteroid == AsteroidAffected)
            {
                GravitationalPull(Asteroid, 30f);
            }
        }
    }

    void OrbSpawner ()
    {
        switch(SelectionNumber)
        {
            case 1:
                Instantiate(Orb, R.gameObject.transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(Orb, L.gameObject.transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(Orb, T.gameObject.transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(Orb, B.gameObject.transform.position, Quaternion.identity);
                break;
            case 5:
                break;
        }
    }

    void GravitationalPull(GameObject t, float multiplier)
    {
            if (GameScript.IsPlayerDead == false)
            {
                Vector3 Diference = transform.position - t.gameObject.transform.position;
                float Distance = Diference.magnitude;
                Vector3 GravityDireccion = Diference.normalized;
                float Gravity = 25f * (this.transform.localScale.x * t.transform.localScale.x * multiplier) / (Distance * Distance);
                Vector3 GravityVector = (GravityDireccion * Gravity);
                t.gameObject.transform.GetComponent<Rigidbody2D>().AddForce(GravityVector, ForceMode2D.Force);
            }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInSight = true;
            PlayerScript.Speed = 14f;
        }

        if (collision.CompareTag("Asteroid"))
        {
            foreach (GameObject Asteroid in AllObjects)
            {
                if (Asteroid == collision.gameObject)
                {
                    AsteroidAffected = collision.gameObject;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInSight = false;
            PlayerScript.Speed = OriginalPlayerSpeed;
        }

        if (collision.CompareTag("Asteroid"))
        {
            if (AsteroidAffected == collision.gameObject)
            {
                AsteroidAffected = null;
            }
        }
    }
}
