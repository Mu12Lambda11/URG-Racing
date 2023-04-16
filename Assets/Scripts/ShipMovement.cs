using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    
    public float turnSpeed = 5f;
    public float acceleration = 5f;
    public float maxSpeed = 10f;
    float forward_move;
    Vector3 rotate_move;
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // Using physics based rotation, so need to rotate in FixedUpdate
        RotateShip();
        MoveShipForward();
    }

    public void Move(float vecMove)
    {
        // Store player's input vector for forward movement
        forward_move = vecMove;
    }

    public void Rotate(Vector3 vecRot)
    {
        // Store player's input vector for rotation
        rotate_move = vecRot;
    }

    private void MoveShipForward()
    {
        Debug.Log(Vector3.right);
        rb.AddForce(transform.right * forward_move * acceleration);
    }

    private void RotateShip()
    {
        rotate_move *= turnSpeed;

        // Rotate the ship using physics based rotation
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotate_move * Time.fixedDeltaTime));
    }
}
