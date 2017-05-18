using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    // Public variables
    public bool isMainMenu = false;
    public float constantSpeed = 8f;
    public float scaleFactor = 8f;

    // Private variables
    private Rigidbody2D rbBall;
    private Text txtPlayerScore;
    private Text txtEnemyScore;

    // Hold the current score
    public static int playerScore = 0;
    public static int enemyScore = 0;

    /// <summary>
    /// Initialize the components.
    /// </summary>
    void Start()
    {
        rbBall = GetComponent<Rigidbody2D>();
        if (!isMainMenu)
        {
            txtPlayerScore = GameObject.Find("Player Score").GetComponent<Text>();
            txtEnemyScore = GameObject.Find("Enemy Score").GetComponent<Text>();
        }
    }

    /// <summary>
    /// Handles the velocity of the ball.
    /// </summary>
    void Update()
    {
        // Move the ball at an angle once the space bar is pressed
        if (rbBall.position.Equals(Vector2.zero))
        {
            if (Input.GetKeyDown(KeyCode.Space) || isMainMenu)
            {
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
        if (transform.position.x < -10)
        {
            enemyScore++;
            rbBall.position = Vector2.zero;
            rbBall.velocity = Vector2.zero;
        }
        
        // Check the right boundary
        if (transform.position.x > 10)
        {
            playerScore++;
            rbBall.position = Vector2.zero;
            rbBall.velocity = Vector2.zero;
        }

        // Perform if actually in game
        if (!isMainMenu)
        {
            // Update the score display
            txtPlayerScore.text = "Player Score: " + playerScore;
            txtEnemyScore.text = "Enemy Score: " + enemyScore;
        }
    }
}