using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private float hInput;
    private float accelInput;
    Vector3 shipMove;
    Vector3 shipRotate;
    ShipMovement SM;

    // Start is called before the first frame update
    void Start()
    {
        // Get access to ship controller
        SM = GetComponent<ShipMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input for left and right movmement
        hInput = Input.GetAxis("Horizontal");

        // Get input for acceleration and deceleraion
        accelInput = Input.GetAxis("Accelerate");

        // Move and rotate the ship
        InputShipMovement();
        // Should add a check to limit whether the ship can rotate when it is not moving
        InputShipTurn();
    }

    private void InputShipMovement()
    {
        // Get player input to move forward and call SM to move ship forward
        // shipMove = new Vector3(accelInput, 0, 0);
        SM.Move(accelInput);
    }

    private void InputShipTurn()
    {
        // Get player input to rotate ship and call SM to rotate ship
        shipRotate = new Vector3(0, hInput, 0);
        SM.Rotate(shipRotate);
    }
}
