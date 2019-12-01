using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode przyciskAktywacji;
    public float throwForce = 40f;
    public float shooting_frequency = 1f;
    public GameObject obiekt;
    public GameObject pasekkolor;
    private Camera cam;
    private bool can_shoot=true;
    private float shoot_time=1f;
    // Update is called once per frame
    void Start()
    {
        shoot_time=shooting_frequency;
        cam = GameObject.Find("mainCamera").GetComponent<Camera>();
    }
    void Update()
    {
        if(pasekkolor!=null)
        {
            pasekkolor.transform.localScale=new Vector3(shoot_time/shooting_frequency,1f,1f);
        }
        if(can_shoot==true)
            {
                if(Input.GetKeyDown(przyciskAktywacji))
                {
                    Throw();
                    can_shoot=false;
                    shoot_time=0;
                }
            }
            else
            {
                if(shoot_time<shooting_frequency)
                {
                    shoot_time+=Time.deltaTime;
                }
                else
                {
                    can_shoot=true;
                }
            }
    }
    void Throw()
    {
        GameObject gren=Instantiate(obiekt, transform.position, transform.rotation);
        Rigidbody rb = gren.GetComponent<Rigidbody>();
        rb.AddForce(cam.transform.forward * throwForce,ForceMode.VelocityChange);
    }
}
