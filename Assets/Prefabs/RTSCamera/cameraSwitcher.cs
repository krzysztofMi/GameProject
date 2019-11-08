using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSwitcher : MonoBehaviour
{
    private GameObject RTSCamera;
    private GameObject player1; 
    private GameObject fpsCamera1;


    void Awake()
    {
        //I'm assigning value to these at the beginning and passing them to functions
        // so that unity will search for them only once
        player1 = GameObject.Find("Player1");
        fpsCamera1 = player1.transform.Find("PlayerCamera").gameObject;
        RTSCamera = transform.Find("RTSCamera").gameObject;

        playerView(player1, fpsCamera1);
    }

    void Update()
    {
        if (Input.GetButton("1"))
        {
            playerView(player1, fpsCamera1);
        }
        if (Input.GetButton("`"))
        {
            rtsView();
        }
        
    }


    private void playerView(GameObject player, GameObject fpsCamera){
        fpsCamera.SetActive(true);
        RTSCamera.SetActive(false);
        player.GetComponent<fpsPlayerMovement>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    } 
    private void rtsView(){
        fpsCamera1.SetActive(false);
        RTSCamera.SetActive(true);
        player1.GetComponent<fpsPlayerMovement>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }
}
