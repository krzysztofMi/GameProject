using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlockZ : MonoBehaviour
{
    public float speed = 10.0f;

    private Vector3 movement;
    public bool rightDirection;
    private int times = 0;
    // Start is called before the first frame update
    void Start()
    {
        movement = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    { 
        if (rightDirection)
        {
            movement.z = speed;
        }
        else
        {
            movement.z = -speed;
        }
        times++;
        transform.Translate(movement * Time.deltaTime);
        if(times == 100)
        {
            times = 0;
            if (rightDirection)
            {
                rightDirection = false;
            }
            else
            {
                rightDirection = true;
            }
        }
    }
}
