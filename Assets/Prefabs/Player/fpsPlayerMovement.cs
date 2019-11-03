using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsPlayerMovement : MonoBehaviour
{
    public float speed = 1.0f; //gdy damy public to pojawia się nowe pole w inspektorze tam gdzie
    //skrypt jest przyczepiony. 1 Domyślna wartość
    private float h, v;

    // Update is called once per frame
    void Update()
    {
        //deltaTime https://www.youtube.com/watch?v=Gcoj3llfzSw&list=PLX2vGYjWbI0S9-X2Q021GUtolTqbUBB9B&index=19
        //GetAxis https://www.youtube.com/watch?v=MK4OmsViqMA&list=PLX2vGYjWbI0S9-X2Q021GUtolTqbUBB9B&index=16
        //transform.translate https://www.youtube.com/watch?v=32JkMANaMpk&list=PLX2vGYjWbI0S9-X2Q021GUtolTqbUBB9B&index=12
        h = Input.GetAxis("Horizontal")*speed*Time.deltaTime;
        v = Input.GetAxis("Vertical")*speed*Time.deltaTime;
        transform.Translate(h, 0, v);
    }
}
