using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour
{
    // Public variables
    public float speed = 8;
    public float yBound = 3.75f;
    public GameObject ball;

    // Private variables
    private Rigidbody2D rbAIPaddle;

    /// <summary>
    /// Initialize the components.
    /// </summary>
    void Start()
    {
        rbAIPaddle = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Handles the tracking of the ball.
    /// </summary>
	void Update ()
    {
        // Get the ball's rigidbody
        Rigidbody2D rbBall = ball.GetComponent<Rigidbody2D>();
        rbAIPaddle.velocity = Vector2.zero;

        // Move down if higher than the ball
        if (rbAIPaddle.position.y > rbBall.position.y)
        {
            rbAIPaddle.velocity = new Vector2(0, -speed);
        }
        // Move up if lower than the ball
        else if (rbAIPaddle.position.y < rbBall.position.y)
        {
            rbAIPaddle.velocity = new Vector2(0, speed);
        }

        // Remain stationary and reset position if the ball stops moving
        if (rbBall.velocity.Equals(Vector2.zero))
        {
            rbAIPaddle.velocity = Vector2.zero;
            rbAIPaddle.position = new Vector2(rbAIPaddle.position.x, 0);
        }

        // Lock the position of the paddle in the boundaries
        Vector3 position = transform.position;
        position.y = Mathf.Clamp(position.y, -yBound, yBound);
        transform.position = position;
    }
}