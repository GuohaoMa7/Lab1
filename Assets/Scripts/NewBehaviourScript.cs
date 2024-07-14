using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    public float speed = 7f; // Speed at which the enemy moves
    public float patrolDistance = 50f; // Distance the enemy will patrol from its starting position

    private Vector3 startPos; // Starting position of the enemy
    private Vector3 moveDirection = Vector3.right; // Initial movement direction

    void Start()
    {
        startPos = transform.position;
        Debug.Log("Start Position: " + startPos);
    }

    void Update()
    {
        // Calculate the target position the enemy should move towards
        Vector3 targetPos = startPos + moveDirection * patrolDistance;

        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // Debug.Log("Target Position: " + targetPos);
        // Debug.Log("Current Position: " + transform.position);

        // Check if the enemy has reached the target position
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            // Change movement direction
            moveDirection = -moveDirection;
            Debug.Log("Changing direction to: " + moveDirection);
        }
    }
}



