using UnityEngine;
public class EnemyFollow : MonoBehaviour
{
    public GameObject objectToFollow;
    public float movementSpeed = 4;

    private void Start()
    {
        if(objectToFollow == null)
        {
            objectToFollow = GameObject.Find("Player");
        }
    }
    void Update()
    {
        transform.LookAt(objectToFollow.transform);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }
}