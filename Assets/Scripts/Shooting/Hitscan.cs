using UnityEngine;

public class Hitscan : MonoBehaviour
{
    public KeyCode przyciskAktywacji;
    public float damage = 10f;
    public float destroyTime = 10f;
    public float shooting_frequency = 1f; //odstęp czasu między strzałami
    public GameObject slad;//kulka zostawiona
    public GameObject pasekkolor;//lewy dolny pasek
    private float shoot_time;
    private Camera cam;
    private bool can_shoot=true;
    private float corruption;
    private fpsPlayerMovement temp;
    void Start()
    {
        shoot_time=shooting_frequency;
        cam = GameObject.Find("mainCamera").GetComponent<Camera>();
        temp = GameObject.Find("Player").GetComponent<fpsPlayerMovement>();
    }
    // Update is called once per frame
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
                Shoot();
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
                shoot_time=shooting_frequency;
                can_shoot=true;
                
            }
        }
        corruption=temp.getMoveLength()/100f;
        if(corruption<0.02f)corruption=0f;
    }

    void Shoot()
    {
        Debug.Log("Strzelanie");
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward+corruptor(corruption), out hit))
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
    Vector3 corruptor(float max)
    {
        return new Vector3(Random.Range(-max,max),Random.Range(-max,max),Random.Range(-max,max));
    }
}
