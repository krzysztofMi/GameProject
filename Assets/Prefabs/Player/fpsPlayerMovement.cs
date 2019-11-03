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
    public CharacterController controller;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
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

        controller.Move(move);

        velocity.y += gravity * Time.deltaTime * Time.deltaTime;
        controller.Move(velocity);
    }
}
