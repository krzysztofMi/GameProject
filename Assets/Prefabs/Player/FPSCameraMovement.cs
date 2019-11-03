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

    //TODO ograniczyc patrzenie w gore bo mozna fikolka zrobic
    void Update()
    {
        //zwroccie uwage na to ze do zarzadzania kamera obracam nie tylko sama kamera, ale 
        //takze graczem. Robie to dlatego, ze gdy obracalem kamera po X i Y to kamera obracala
        //sie takze po Z jest to nie intuicyjne, ale poobracajcie sobie kostke po X i Y 
        //w edytorze unity a zobaczycie, ze to faktyczne zachowanie 3D obiektow.

        //deltaTime https://www.youtube.com/watch?v=Gcoj3llfzSw&list=PLX2vGYjWbI0S9-X2Q021GUtolTqbUBB9B&index=19
        //GetAxis https://www.youtube.com/watch?v=MK4OmsViqMA&list=PLX2vGYjWbI0S9-X2Q021GUtolTqbUBB9B&index=16
        //transform.Rotate https://www.youtube.com/watch?v=32JkMANaMpk&list=PLX2vGYjWbI0S9-X2Q021GUtolTqbUBB9B&index=12s
        mouseX = Input.GetAxis("Mouse X")*mousesSensitivity*Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y")*mousesSensitivity*Time.deltaTime;
        player.transform.Rotate(0, mouseX, 0); //operujemy na zewnętrznym obiekcie
        transform.Rotate(-mouseY, 0, 0); //operujemy na obiekcie do którego jest ten skrypt przyczepiony
        
    }
}
