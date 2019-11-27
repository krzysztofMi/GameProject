
using UnityEngine;

public class Hitscan : MonoBehaviour
{

    public float damage = 10f;
    public float destroyTime;
    private Camera cam;
    public GameObject slad;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("mainCamera").GetComponent<Camera>();
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
            Destroy(obiekt, destroyTime);
        }
    }
}
