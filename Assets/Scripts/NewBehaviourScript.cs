using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f; // Adjusted speed for the smaller character
    public float patrolDistance = 2f; // Half of the total patrol distance (4 units)

    private Vector3 startPos; // Starting position of the enemy
    private Vector3 leftBound;
    private Vector3 rightBound;
    private Vector3 moveDirection = Vector3.right; // Initial movement direction

    void Start()
    {
        startPos = transform.position;
        leftBound = startPos - Vector3.right * patrolDistance;
        rightBound = startPos + Vector3.right * patrolDistance;
        Debug.Log("Start Position: " + startPos);
        Debug.Log("Left Bound: " + leftBound);
        Debug.Log("Right Bound: " + rightBound);
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
