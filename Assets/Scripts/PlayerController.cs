using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;  // Force applied to the jump
    public float forwardSpeed = 2f;  // Constant forward speed

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Set initial velocity to move the player forward
        rb.velocity = new Vector2(forwardSpeed, rb.velocity.y);
    }

    void Update()
    {
        // Check for input to make the player jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        // Reset the y velocity and apply a new jump force
        rb.velocity = new Vector2(rb.velocity.x, 0);  // Clear any downward motion
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player hits an obstacle or ground, end the game
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Game Over!");
            // Here you could add code to reset the game or show a game-over screen
        }
    }
}
