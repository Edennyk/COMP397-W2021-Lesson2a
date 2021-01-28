using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float movementForce;
    public float jumpForce;
    public Rigidbody rigidBody;
    public bool isGrounded;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame - once every 16.6666ms
    // 1000ms for each second
    // approximately updates 60 times per second = 60fps(frame per second)
    void Update()
    {
        if(isGrounded)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                // move to the right
                // Debug.Log("Moving Right");
                rigidBody.AddForce(Vector3.right * movementForce);
            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                // move to the left
                //Debug.Log("Moving Left");
                rigidBody.AddForce(Vector3.left * movementForce);
            }

            if (Input.GetAxisRaw("Vertical") > 0)
            {
                // move to the forward
                rigidBody.AddForce(Vector3.forward * movementForce);
            }
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                // move to the back
                rigidBody.AddForce(Vector3.back * movementForce);
            }

            if(Input.GetAxisRaw("Jump") > 0)
            {
                // jumping
                rigidBody.AddForce(Vector3.up * jumpForce);
            }
        }
    }

     void OnCollisionEnter(Collision other)
     {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
     }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
