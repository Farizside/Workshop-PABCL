using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float moveSpeed;

    private float xInput;

    private float yInput;

    private float zInput;
    
    bool canJump = true;
    
    public float jumpForce;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ProcessInputs()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        if (canJump)
        {
            yInput = Input.GetAxis("Jump") * jumpForce;
        }
    }

    private void Move()
    {
        rb.AddForce(new Vector3(xInput, yInput, zInput) * (moveSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            canJump = false;
            yInput = 0f;
        }
    }
}
