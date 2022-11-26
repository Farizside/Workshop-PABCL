using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;
    public float jump;

    private bool _canJump;

    public Camera view;

    // Use this for initialization
    void Start () {
		
    }
	
    // Update is called once per frame
    void Update () 
    {
        // Up or Down
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody>().AddForce(view.transform.forward * speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody>().AddForce(view.transform.forward * -speed);
        }

        // Left or Right
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody>().AddForce(view.transform.right * -speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().AddForce(view.transform.right * speed);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && _canJump)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jump, 0));
            _canJump = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _canJump = true;
        }
    }
}
