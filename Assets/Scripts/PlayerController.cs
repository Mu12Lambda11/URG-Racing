using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float hInput;
    private float accelerateInput;
    public float turnSpeed = 5f;
    public float acceleration = 5f;
    public float maxSpeed = 10f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Get the player's rigidbody
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input for left and right movmement
        hInput = Input.GetAxis("Horizontal");

        // Get input for acceleration and deceleraion
        accelerateInput = Input.GetAxis("Accelerate");

        // Rotate the ship
        // Should add a check to limit whether the ship can rotate when it is not moving
        // transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * hInput);

        // Move the player forward or backward
        
    }

    private void FixedUpdate()
    {
        // Using physics based rotation, so need to rotate in FixedUpdate
        rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, hInput * turnSpeed, 0) * Time.fixedDeltaTime));
    }
}
