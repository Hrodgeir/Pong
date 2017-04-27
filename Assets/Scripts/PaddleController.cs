using UnityEngine;
using System.Collections;
using System;

public class PaddleController : MonoBehaviour
{
    public float speed = 8;
    public float yBound = 3.75f;
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

        if (y < 0)
        {
            rbPaddle.velocity = new Vector2(0, -speed);
        }
        else if (y > 0)
        {
            rbPaddle.velocity = new Vector2(0, speed);
        }
        else
        {
            rbPaddle.velocity = new Vector2(0, 0);
        }

        Vector3 position = transform.position;
        position.y = Mathf.Clamp(position.y, -yBound, yBound);
        transform.position = position;
    }
}