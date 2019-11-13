using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    // Start is called before the first frame update
    public float throwForce = 40f;
    public GameObject grenObj;
    public Camera cam;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ThrowGrenade();
        }
    }
    void ThrowGrenade()
    {
        GameObject gren=Instantiate(grenObj, transform.position, transform.rotation);
        Rigidbody rb = gren.GetComponent<Rigidbody>();
        rb.AddForce(cam.transform.forward * throwForce,ForceMode.VelocityChange);
    }
}
