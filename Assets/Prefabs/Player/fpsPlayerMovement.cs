using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//deltaTime https://www.youtube.com/watch?v=Gcoj3llfzSw&list=PLX2vGYjWbI0S9-X2Q021GUtolTqbUBB9B&index=19
//GetAxis https://www.youtube.com/watch?v=MK4OmsViqMA&list=PLX2vGYjWbI0S9-X2Q021GUtolTqbUBB9B&index=16
//gravity based on this video https://www.youtube.com/watch?v=_QajrabyTJc
public class fpsPlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float gravity = -9.81f * 0.1f;
    public float jumpSpeed = 15f;
    public float groundDistance = 4.4f;
    
    private LayerMask groundMask;
    private Vector3 move;
    private bool isGrounded;
    private Transform groundCheck;
    private CharacterController controller;
    private void Start()
    {
        GameObject gobject = GameObject.Find("PlayerGroundCheck");
        groundCheck = gobject.transform;
        controller = GetComponent<CharacterController>();
        groundMask = LayerMask.GetMask("Ground");
        move = new Vector3(0.0f, 0.0f, 0.0f);
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        move.x = Input.GetAxis("Horizontal") * speed;
        move.z = Input.GetAxis("Vertical") * speed;
        move = transform.TransformDirection(move);

        if (isGrounded == true)
        { //(isGrounded && velocity.y < 0)
            move.y = gravity / 8;
            if (Input.GetButton("Jump"))
            {
                move.y += jumpSpeed;
            }
            if (Input.GetKey((KeyCode.LeftShift)))
            {
                move.x *= 2;
                move.z *= 2;
            }
        }

        move.y += gravity;
        controller.Move(move * Time.deltaTime);
    }
}
