using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSCameraMovement : MonoBehaviour
{
    public float speed=20.0f;
    private float v, h;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        v = Input.GetAxis("Vertical")*Time.deltaTime*speed;
        h = Input.GetAxis("Horizontal")*Time.deltaTime*speed;
        transform.Translate(transform.forward * v);
        transform.Translate(transform.right * h);
    }
}
