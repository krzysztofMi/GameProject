using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GumProjectile : MonoBehaviour
{
    public int destroyTime = 10;
    public float speed =10f;
    Vector3 vec = Vector3.one;
    public GameObject gum;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position+=transform.forward;
        Destroy(gameObject,destroyTime);
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(),GameObject.Find("Player").GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+=transform.forward*Time.deltaTime*speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hej");
        GameObject temp=Instantiate(gum,gameObject.transform.position,gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
