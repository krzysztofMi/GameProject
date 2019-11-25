using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public Vector3 startPosition;


    public void Start()
    {
        startPosition = transform.position;
    }
    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if(health<=0)
        {
            Destroy(gameObject);
        }
    }

    public void playerTakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            transform.position = startPosition;
        }

    }
}
