using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlockX : MonoBehaviour
{
    public float speed = 10.0f;

    private Vector3 movement;
    public bool forwardDirection;
    private int times = 0;
    // Start is called before the first frame update
    void Start()
    {
        movement = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (forwardDirection)
        {
            movement.x = speed;
        }
        else
        {
            movement.x = -speed;
        }
        times++;
        transform.Translate(movement * Time.deltaTime);
        if (times == 100)
        {
            times = 0;
            if (forwardDirection)
            {
                forwardDirection = false;
            }
            else
            {
                forwardDirection = true;
            }
        }
    }
}
