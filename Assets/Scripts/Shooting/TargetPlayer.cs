using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayer : MonoBehaviour, ITarget
{
    // Start is called before the first frame update
    public float health = 50.0f;
    private float startHealth;
    private Vector3 startPosition;
    private CharacterController characterController;

    void Start()
    {
        startPosition = transform.position;
        characterController = GetComponent<CharacterController>();
        startHealth = health;
    }

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
            characterController.enabled = false;
            transform.position = startPosition;
            characterController.enabled = true;
            health = startHealth;
        }
    }
}
