
using UnityEngine;

public class Hitscan : MonoBehaviour
{
    public KeyCode przyciskAktywacji;
    public float damage = 10f;
    public float destroyTime = 10f;
    public float shooting_frequency = 1f;
    private float shoot_time=0f;
    public GameObject slad;
    private Camera cam;
    private bool can_shoot=true;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("mainCamera").GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        if(can_shoot==true)
        {
            if(Input.GetKeyDown(przyciskAktywacji))
            {
                Shoot();
                can_shoot=false;
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
                shoot_time=0;
            }
        }
    }

    void Shoot()
    {
        Debug.Log("Strzelanie");
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            Debug.Log("Namierzony obiekt: " + hit.transform.name);
            ITarget target = hit.transform.GetComponent<ITarget>();
            if(target!=null)
            {
                target.TakeDamage(damage);
                Debug.Log("Pozostałe życie: "+ target.getHealth());
            }
            GameObject obiekt=Instantiate(slad, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(obiekt, destroyTime);
        }
    }
}
