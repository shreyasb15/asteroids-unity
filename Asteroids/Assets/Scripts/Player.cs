using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float thrustSpeed = 1f;
    public float turnSpeed = 1f;

    private Rigidbody2D rb;
    private bool thrusting;
    private float turnDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            turnDirection = 1f;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            turnDirection = -1f;
        }
        else
        {
            turnDirection = 0f;
        }
    }

    private void FixedUpdate()
    {
        if(thrusting)
        {
            rb.AddForce(this.transform.up * thrustSpeed);
        }

        if(turnDirection != 0)
        {
            rb.AddTorque(turnDirection * this.turnSpeed);
        }
    }
}
