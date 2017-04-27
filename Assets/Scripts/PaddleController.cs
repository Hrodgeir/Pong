using UnityEngine;
using System.Collections;
using System;

public class PaddleController : MonoBehaviour
{
    private float minY = -3.75f;
    private float maxY = 3.75f;

    public float speed = 10;

    void Update()
    {
        MovePaddle();
    }

    private void MovePaddle()
    {
        float movement = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector2 position = transform.position;
        position.y = Mathf.Clamp(position.y + movement, minY, maxY);
        transform.position = position;
    }
}