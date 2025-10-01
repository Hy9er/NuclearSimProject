using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyaerMovement : MonoBehaviour
{
    public float MovementSpeed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");

        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //if player is still, slow down until stop. Else move forward
        if (moveDirection.magnitude == 0)
        {
            rb.AddForce(-10f * rb.velocity);
        }
        else
        {
            rb.AddForce(moveDirection.normalized * MovementSpeed * 10f, ForceMode.Force);
        }
            
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > MovementSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * MovementSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }


    }


}
