using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gum : MonoBehaviour
{
    float time = 0.3f;
    float x = 0;
    bool zmiejszanie = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    Vector3 vec = Vector3.one;
    // Update is called once per frame
    void Update()
    {
        if(x<time && zmiejszanie==true)
        {
            x += Time.deltaTime;
        }
        else
        {
            zmiejszanie = false;
            x -= Time.deltaTime/10;
        }
        transform.localScale = vec*(x/time * 3f);
        if(x<=0.01f)
        {
            Destroy(gameObject);
            Destroy(this);
        }
    }
}
