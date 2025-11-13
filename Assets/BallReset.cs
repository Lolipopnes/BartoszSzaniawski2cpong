using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour
{
    private Vector3 originalPosition;

    void Start()
    {
        // Store the ball’s starting position
        originalPosition = transform.position;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Option 1: check by object name
        if (collision.gameObject.name == "RightBorder")
        {
            ResetBall();
        }

        // OR Option 2: check by tag (recommended)
        // if (collision.gameObject.CompareTag("RightBorder"))
        // {
        //     ResetBall();
        // }
    }

    private void ResetBall()
    {
        // Reset position to where it started
        transform.position = originalPosition;

        // If it has a Rigidbody, stop all motion
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
