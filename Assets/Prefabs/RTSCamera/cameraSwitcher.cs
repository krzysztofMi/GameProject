using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSwitcher : MonoBehaviour
{
    private GameObject RTSCamera;
    private GameObject player1; 
    private GameObject fpsCamera1;


    // Start is called before the first frame update
    void Awake()
    {
        player1 = GameObject.Find("Player1");
        fpsCamera1 = player1.transform.Find("PlayerCamera").gameObject;
        RTSCamera = transform.Find("RTSCamera").gameObject;

        fpsCamera1.SetActive(false);
        RTSCamera.SetActive(true);
        player1.GetComponent<fpsPlayerMovement>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("1"))
        {
            fpsCamera1.SetActive(true);
            RTSCamera.SetActive(false);
            player1.GetComponent<fpsPlayerMovement>().enabled = true;
        }
        if (Input.GetButton("`"))
        {
            fpsCamera1.SetActive(false);
            RTSCamera.SetActive(true);
            player1.GetComponent<fpsPlayerMovement>().enabled = false;
        }
        
    }
}
