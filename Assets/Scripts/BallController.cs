using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    public float speed;
    public float jump;

    private bool _isGrounded;
    public GameManager gm;

    public Camera view;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -30, 0);
    }
	
    // Update is called once per frame
    void Update () 
    {
        if (gm.isGameOver)
        {
            rb.velocity = Vector3.zero;
            return;
        }
        // Up or Down
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(view.transform.forward * speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
           rb.AddForce(view.transform.forward * -speed);
        }

        // Left or Right
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(view.transform.right * -speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(view.transform.right * speed);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            rb.AddForce(new Vector3(0, jump, 0));
            _isGrounded = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _isGrounded = true;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            gm.collectedStars++;
            Destroy(other.gameObject);
            gm.DisplayStars();
        }
    }
}
