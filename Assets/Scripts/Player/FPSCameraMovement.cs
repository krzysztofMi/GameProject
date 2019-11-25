using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraMovement : MonoBehaviour
{
    public float mousesSensitivity = 100.0f;
    //tutaj deklarujemy zewnętrzny obiekt, gdy damy mu public to wyświetla się nowe pole w inspektorze
    //w Unity w componencie który nazywa się tak jak skrypt
    //i przeciągamy na to pole obiekt gracza ze sceny. Dzięki temu możemy na nim operować.
    public GameObject player;

    private float mouseX;
    private float mouseY;
    private float xRotation;


    void Update()
    {
        //zwroccie uwage na to ze do zarzadzania kamera obracam nie tylko sama kamera, ale 
        //takze graczem. Robie to dlatego, ze gdy obracalem kamera po X i Y to kamera obracala
        //sie takze po Z jest to nie intuicyjne, ale poobracajcie sobie kostke po X i Y 
        //w edytorze unity a zobaczycie, ze to faktyczne zachowanie 3D obiektow.
        
        mouseX = Input.GetAxis("Mouse X")*mousesSensitivity*Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y")*mousesSensitivity*Time.deltaTime;

        //Locking the horizontal camera rotation to 90 degrees.
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        player.transform.Rotate(0, mouseX, 0); //rotating the player
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //rotating the camera
        
    }
}
