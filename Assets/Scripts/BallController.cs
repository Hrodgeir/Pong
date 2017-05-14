using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
    public float constantSpeed = 8.0f;
    public float scaleFactor = 8.0f;

    private Rigidbody2D rbBall;

    // Hold the current score.
    public static int playerScore = 0;
    public static int enemyScore = 0;

    /// <summary>
    /// Initialize the components.
    /// </summary>
    void Start()
    {
        rbBall = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Handles the velocity of the ball.
    /// </summary>
    void Update()
    {
        // Move the ball at an angle once the space bar is pressed
        if (rbBall.position.Equals(Vector2.zero))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Round started.");

                // Generate a random value to determine which direction the ball will move
                float startingSpeed = constantSpeed;
                float randomVal = Random.value;
                if (randomVal > 0.5)
                {
                    startingSpeed *= -1;
                }

                rbBall.AddForce(new Vector2(startingSpeed, constantSpeed));
            }
            else
            {
                return;
            }
        }

        // Handle the ball's velocity while the game is running
        Vector2 curVel = rbBall.velocity;
        Vector2 newVel = curVel.normalized * constantSpeed;
        rbBall.velocity = Vector2.Lerp(curVel, newVel, Time.deltaTime * scaleFactor);

        // Check the left boundary
        if (transform.position.x < -7)
        {
            enemyScore++;
            rbBall.position = Vector2.zero;
            rbBall.velocity = Vector2.zero;
        }
        
        // Check the right boundary
        if (transform.position.x > 7)
        {
            playerScore++;
            rbBall.position = Vector2.zero;
            rbBall.velocity = Vector2.zero;
        }

        Debug.Log("Player Score: " + playerScore);
        Debug.Log("Enemy Score: " + enemyScore);
    }
}