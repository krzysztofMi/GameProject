
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float damage = 10f;
    public float destroyTime;
    private Camera cam;
    public GameObject bullet;
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
        GameObject temp = Instantiate(bullet, cam.transform.position, cam.transform.rotation);
    }
}
