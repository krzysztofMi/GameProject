using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, ITarget
{
    public float health = 50.0f;

    public float getHealth()
    {
        return health;
    }

    public void setHealth(float health)
    {
        this.health = health;
    }

    public void TakeDamage(float takenDmg)
    {
        health -= takenDmg;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
