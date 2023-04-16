using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] Transform boxCast;
    private Vector3 castCenter;
    private Vector3 halfExtents;
    [SerializeField] float boxCastDistance = 1f;
    public float hoverDistance = 5f;
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

        // Get reference to the cast box to know where to cast from
        castCenter = boxCast.localPosition;
        halfExtents = boxCast.localScale / 2;

        // Delete the box after we get the necessary info
        Destroy(boxCast.gameObject);
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
        HoverShip();
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
        rb.AddForce(transform.right * forward_move * acceleration, ForceMode.Acceleration);
    }

    private void RotateShip()
    {
        Vector3 rotVector = rotate_move * turnSpeed;

        // Rotate the ship using physics based rotation
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotVector * Time.fixedDeltaTime));

        // rb.AddTorque()
    }

    private void HoverShip()
    {
        // BoxCast with everything except the player
        RaycastHit hit;
        bool didHit = Physics.BoxCast(transform.position + castCenter, halfExtents, -transform.up, out hit, transform.rotation, boxCastDistance, ~LayerMask.GetMask("Player"));

        if(didHit)
        {
            Debug.Log("We hit!!");
            // If we hit something, set our position to hover over it a set distance
            transform.position = new Vector3(transform.position.x, hit.point.y + hoverDistance, transform.position.z);
        }
    }
}
