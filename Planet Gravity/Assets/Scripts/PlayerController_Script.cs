using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Script : MonoBehaviour
{
    public Joystick MovementJoystick;
    private float Speed = 10f;
    private Rigidbody2D rb;
    private Vector3 Direction;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Direction = Vector3.up * -MovementJoystick.Vertical + Vector3.right * -MovementJoystick.Horizontal;
        rb.AddForce(Direction * Speed, ForceMode2D.Force);
    }
}
