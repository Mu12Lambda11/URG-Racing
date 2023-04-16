using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotatespeed = 10f;
    public Transform player;
    Vector3 offset;

    private void LateUpdate()
    {
        // Rotate the anchor to match the player's rotation
        transform.root.rotation = player.rotation;
        transform.root.position = player.position;

        // Move camera to follow the player's position
        // transform.position = player.position + offset;
    }
}
