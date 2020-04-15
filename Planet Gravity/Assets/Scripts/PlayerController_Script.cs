using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Script : MonoBehaviour
{
    // Movement
    public Joystick MovementJoystick;
    private float Speed = 8f;
    private Rigidbody2D rb;
    private Vector3 Direction;

    // Movement rotation
    public GameObject Pivot;
    public Quaternion LastPivot;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movement();
        MovementRotation();
    }

    void Movement()
    {
        Direction = Vector3.up * -MovementJoystick.Vertical + Vector3.right * -MovementJoystick.Horizontal;
        rb.AddForce(Direction * Speed, ForceMode2D.Force);
    }

    void MovementRotation()
    {
        float Direction = Mathf.Atan2(-MovementJoystick.Horizontal, -MovementJoystick.Vertical);
        float Still = MovementJoystick.Horizontal * MovementJoystick.Vertical;

        if (Still != 0)
        {
            Pivot.transform.rotation = Quaternion.Euler(0f, 0f, -Direction * Mathf.Rad2Deg);
            LastPivot = Quaternion.Euler(0f, 0f, -Direction * Mathf.Rad2Deg);
        }
        else
        {
            Pivot.transform.rotation = LastPivot;
        }
    }


}
