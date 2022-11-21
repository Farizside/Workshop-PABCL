using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float moveSpeed;

    private float _xInput;

    private float _yInput;

    private float _zInput;

    private string _facing;
    
    bool _canJump = true;
    
    public float jumpForce;
    // Start is called before the first frame update
    private void Start()
    {
        _facing = "utara";
    }

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
        _xInput = Input.GetAxis("Horizontal");
        _zInput = Input.GetAxis("Vertical");
        if (_canJump)
        {
            _yInput = Input.GetAxis("Jump") * jumpForce;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _facing = "barat";
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _facing = "utara";
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _facing = "timur";
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            _facing = "selatan";
        }
    }

    private void Move()
    {
        switch (_facing)
        {
            case ("barat") : 
                rb.AddForce(new Vector3(-_zInput, _yInput, _xInput) * (moveSpeed * Time.deltaTime));
                break;
            case ("utara") : 
                rb.AddForce(new Vector3(_xInput, _yInput, _zInput) * (moveSpeed * Time.deltaTime));
                break;
            case ("timur") :
                rb.AddForce(new Vector3(_zInput, _yInput, -_xInput) * (moveSpeed * Time.deltaTime));
                break;
            case ("selatan") :
                rb.AddForce(new Vector3(-_xInput, _yInput, -_zInput) * (moveSpeed * Time.deltaTime));
                break;
            default:
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _canJump = true;
            _yInput = 0f;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _canJump = false;
            _yInput = -2f;
        }
    }
}
