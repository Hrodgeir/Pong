using UnityEngine;
using System.Collections;
using System;

public class PaddleController : MonoBehaviour
{
    // Public variables
    public float speed = 6f;
    public float yBound = 3f;

    // Private variables
    private Rigidbody2D rbPaddle;

    /// <summary>
    /// Initialize the components.
    /// </summary>
    void Start()
    {
        rbPaddle = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Move the paddle depending on the direction specified.
    /// </summary>
    void Update()
    {
        float y = Input.GetAxisRaw("Vertical");
        rbPaddle.velocity = Vector2.zero;

        // Move down if button pressed
        if (y < 0)
        {
            rbPaddle.velocity = new Vector2(0, -speed);
        }
        // Move up if button pressed
        else if (y > 0)
        {
            rbPaddle.velocity = new Vector2(0, speed);
        }
        // Remain stationary if no input
        else
        {
            rbPaddle.velocity = Vector2.zero;
        }

        // Lock the position of the paddle in the boundaries
        Vector3 position = transform.position;
        position.y = Mathf.Clamp(position.y, -yBound, yBound);
        transform.position = position;
    }
}