using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    public float gravity = -9.81f * 0.1f;
    public float groundDistance = 0.4f;
    private LayerMask groundMask;
    private bool isGrounded;
    private Transform groundCheck;

    private Vector3 velocity;
    void Start()
    {
        groundCheck = GameObject.FindGameObjectWithTag("groundCheck").transform;
        groundMask = LayerMask.GetMask("Ground");
     
    }

    
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded == true)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity;
        }
        transform.Translate(velocity * Time.deltaTime);
    }
}
