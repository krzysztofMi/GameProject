using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSCameraMovement : MonoBehaviour
{
    public float horizontalSpeed=25.0f;
    public float verticalSpeed=15.0f;
    public float screenEdgeThickness = 50f; //for controlling camera with mouse
    public float scrollSpeed = 1000.0f;

    Vector3 newPos;
    void Start()
    {
        newPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        handleMovementInput();
    }

    void handleMovementInput()
    {
        if(Input.GetButton("up") || Input.mousePosition.y >= Screen.height - screenEdgeThickness)
        {
            newPos.z += verticalSpeed * Time.deltaTime; 
        }
        if(Input.GetButton("down") || Input.mousePosition.y <= screenEdgeThickness)
        {
            newPos.z -= verticalSpeed * Time.deltaTime;
        }
        if(Input.GetButton("right") || Input.mousePosition.x >= Screen.width - screenEdgeThickness)
        {
            newPos.x += horizontalSpeed * Time.deltaTime;
        }
        if(Input.GetButton("left") || Input.mousePosition.x <= screenEdgeThickness)
        {
           newPos.x -= horizontalSpeed * Time.deltaTime;
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        newPos.y -= scroll*scrollSpeed*Time.deltaTime;

        transform.position = newPos;

    }
}
