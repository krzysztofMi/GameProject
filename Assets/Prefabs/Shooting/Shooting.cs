
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public float damage = 10f;
    public Camera cam;
    public GameObject slad;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log("Strzelanie");
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            Debug.Log("Namierzony obiekt: " + hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if(target!=null)
            {
                target.TakeDamage(damage);
                Debug.Log("Pozostałe życie: "+ target.health);
            }
            GameObject obiekt=Instantiate(slad, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(obiekt, 3f);
        }
    }
}
