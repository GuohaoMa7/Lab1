using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float jumpForce = 6f;

    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        score = 0;
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if space is pressed down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    // FixedUpdate is called once every physics update
    private void FixedUpdate()
    {
        rigidbodyComponent.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, 0);

        if (!IsGrounded())
        {
            return;
        }

        if (jumpKeyWasPressed)
        {
            rigidbodyComponent.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }
    }

    // Check if the player is grounded
    private bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheckTransform.position, 0.1f, playerMask);
    }

    // Update ScoreText
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    // Increase the score
    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
    }

    // OnTriggerEnter
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            IncreaseScore();
        }
    }
}
