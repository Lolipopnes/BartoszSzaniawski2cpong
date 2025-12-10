using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1 : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector3 startPosition;

    private float moveInput;

    [Header("Clamp Settings")]
    public float topLimit = 4f;    
    public float bottomLimit = -4f; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    void Update()
    {
        moveInput = 0f;
        if (Input.GetKey(KeyCode.W)) moveInput = 1f;
        if (Input.GetKey(KeyCode.S)) moveInput = -1f;
    }

    void FixedUpdate()
    {
        Vector2 position = rb.position;
        position.y += moveInput * moveSpeed * Time.fixedDeltaTime;

        
        position.y = Mathf.Clamp(position.y, bottomLimit, topLimit);

        rb.MovePosition(position);
    }

    public void ResetPosition()
    {
        rb.position = startPosition;
    }
}

