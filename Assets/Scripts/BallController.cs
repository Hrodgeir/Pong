using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
    public float force;
    private Rigidbody2D rbBall;

    /// <summary>
    /// Initialize the components.
    /// </summary>
    void Start()
    {
        rbBall = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Applies forces to the ball for startup and if it 
    /// gets locked in a horizontal or vertical movement.
    /// </summary>
    void FixedUpdate()
    {
        //Debug.Log("Ball velocity: " + rbBall.velocity.magnitude);

        // Move the ball at an angle once the space bar is pressed.
        if (rbBall.velocity.magnitude == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Game started.");
                rbBall.AddForce(new Vector2(force, force));
            }
            else
            {
                return;
            }
        }

        // Add some force if the ball is not moving horizontally.
        if (rbBall.velocity.x < 0.1 && rbBall.velocity.x > 0.1)
        {
            rbBall.AddForce(new Vector2(force, 0));
        }

        // Add some force if the ball is not moving vertically.
        if (rbBall.velocity.y < 0.1 && rbBall.velocity.y > -0.1)
        {
            rbBall.AddForce(new Vector2(0, force));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ball collided with something.");

        Vector2 moreSpeed = rbBall.velocity;

    }
}