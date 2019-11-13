using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 5f;
    public float damage = 20f;
    public GameObject explosion;
    float countdown;
    bool exploded = false;
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown<=0f && exploded==false)
        {
            Explode();
            exploded = true;
        }
    }
    void Explode()
    {
        Debug.Log("Boom");
        Collider [] col = Physics.OverlapSphere(transform.position,radius);
        GameObject temp = Instantiate(explosion, transform.position, Quaternion.identity);
        foreach (Collider obj in col)
        {
            Target t = obj.GetComponent<Target>();
            if(t!=null)
            {
                t.TakeDamage(damage);
                Debug.Log("Pozostałe życie: " + t.health);
            }
        }
        Destroy(gameObject);
        Destroy(temp, 1f);
    }
}
