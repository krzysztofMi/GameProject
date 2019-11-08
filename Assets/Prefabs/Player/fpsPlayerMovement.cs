using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//deltaTime https://www.youtube.com/watch?v=Gcoj3llfzSw&list=PLX2vGYjWbI0S9-X2Q021GUtolTqbUBB9B&index=19
//GetAxis https://www.youtube.com/watch?v=MK4OmsViqMA&list=PLX2vGYjWbI0S9-X2Q021GUtolTqbUBB9B&index=16
//gravity based on this video https://www.youtube.com/watch?v=_QajrabyTJc
public class fpsPlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float gravity = -9.81f * 0.1f;
    public float jumpSpeed = 15f;

    public float groundDistance = 0.4f;
<<<<<<< HEAD
    public LayerMask groundMask;
    Vector3 velocity;
    float h, v;
    bool isGrounded;
    
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded == true) //(isGrounded && velocity.y < 0)
            velocity.y = gravity / 8;
        h = Input.GetAxis("Horizontal")*speed*Time.deltaTime;
        v = Input.GetAxis("Vertical")*speed*Time.deltaTime;
        Vector3 move = transform.right * h + transform.forward * v;
=======
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
>>>>>>> 7169b443bfc2278def666800dabea15fb786e060

        if (isGrounded == true)
        { //(isGrounded && velocity.y < 0)
            move.y = gravity / 8;
            if (Input.GetButton("Jump"))
            {
                move.y += jumpSpeed;
            }
        }

        move.y += gravity;
        controller.Move(move * Time.deltaTime);
    }
}
