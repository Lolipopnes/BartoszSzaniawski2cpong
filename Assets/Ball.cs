using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 300f;
    private Rigidbody2D rb;
    private Vector3 originalPosition;
    private bool waitingForInput = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPosition = transform.position;

       
        WaitForLaunch();
    }

        void Update()
    {
        
        if (!PauseManagerIsPaused() && waitingForInput && Input.GetKeyDown(KeyCode.Space))
        {
            LaunchBall();
            waitingForInput = false;
        }
    }

    
    bool PauseManagerIsPaused()
    {
        PauseManager pm = FindObjectOfType<PauseManager>();
        return pm != null && pm.IsPaused();
    }

    public P1 paddle1;
    public P2 paddle2;

    public void ResetBall()
    {
        
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        transform.position = originalPosition;

     
        if (paddle1 != null) paddle1.ResetPosition();
        if (paddle2 != null) paddle2.ResetPosition();

        
        WaitForLaunch();
    }


    void WaitForLaunch()
    {
        waitingForInput = true;
    }

    void LaunchBall()
    {
        float xDir = Random.value < 0.5f ? -1 : 1;
        float yDir = Random.Range(-0.5f, 0.5f);
        rb.velocity = Vector2.zero; 
        rb.AddForce(new Vector2(xDir, yDir) * speed);
        Debug.Log("x " + xDir + " y " + yDir);
    }
}
