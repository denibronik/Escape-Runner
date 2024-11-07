using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    [SerializeField] private float minY; // Minimum Y position threshold
    [SerializeField] private float maxY; // Maximum Y position threshold

    private void Update()
    {
        // Calculate the target position with constraints on the Y-axis.
        float targetPosY = Mathf.Clamp(player.position.y, minY, maxY);
        
        // Set the camera's position, applying the X and Y constraints.
        transform.position = new Vector3(player.position.x + lookAhead, targetPosY, transform.position.z);

        // Smoothly adjust the lookAhead value based on player's scale and direction.
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }
}
