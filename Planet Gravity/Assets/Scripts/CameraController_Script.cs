using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController_Script : MonoBehaviour
{
    // Movement
    private Vector2 velocity;
    public float smoothTimeY;
    public float smoothTimeX;
    public float OffsetY;
    public float OffsetX;

    // References
    private GameObject Player;
    GameController_Script GameScript;

    private void Start()
    {
        GameScript = FindObjectOfType<GameController_Script>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if (GameScript.IsPlayerDead == false)
        {
            float posX = Mathf.SmoothDamp(transform.position.x, Player.transform.position.x + OffsetX, ref velocity.x, smoothTimeX);
            float posY = Mathf.SmoothDamp(transform.position.y, Player.transform.position.y + OffsetY, ref velocity.y, smoothTimeY);
            transform.position = new Vector3(posX, posY, transform.position.z);
        }
    }
}
