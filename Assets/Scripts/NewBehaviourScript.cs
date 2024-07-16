using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0.5f; // Adjusted speed for smoother movement
    public float patrolDistance = 2f; // Half of the total patrol distance (4 units)

    private Vector3 startPos; // Starting position of the enemy
    private Vector3 leftBound;
    private Vector3 rightBound;
    private Vector3 moveDirection; // Initial movement direction

    void Start()
    {
        startPos = transform.position;
        leftBound = startPos - Vector3.right * patrolDistance;
        rightBound = startPos + Vector3.right * patrolDistance;

        // Determine initial movement direction based on the starting position
        if (startPos.x <= leftBound.x)
        {
            moveDirection = Vector3.right; // Move right if starting at or near the left bound
        }
        else if (startPos.x >= rightBound.x)
        {
            moveDirection = Vector3.left; // Move left if starting at or near the right bound
        }
        else
        {
            moveDirection = Vector3.right; // Default to moving right
        }

        Debug.Log("Start Position: " + startPos);
        Debug.Log("Left Bound: " + leftBound);
        Debug.Log("Right Bound: " + rightBound);
        Debug.Log("Initial Direction: " + moveDirection);
    }

    void Update()
    {
        // Move towards the current direction
        transform.position += moveDirection * speed * Time.deltaTime;

        // Check if the enemy has reached the left or right bound
        if (moveDirection == Vector3.right && transform.position.x >= rightBound.x)
        {
            moveDirection = Vector3.left;
            Debug.Log("Changing direction to: " + moveDirection);
        }
        else if (moveDirection == Vector3.left && transform.position.x <= leftBound.x)
        {
            moveDirection = Vector3.right;
            Debug.Log("Changing direction to: " + moveDirection);
        }
    }
}
