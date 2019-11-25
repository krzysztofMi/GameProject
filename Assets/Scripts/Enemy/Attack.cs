using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage = 5;
    public GameObject attackedObject;
    private GameObject weapon;
    private Animator animator;
    private bool isPlaying = false;
   
    void Start()
    {
        if(attackedObject == null)
        {
            attackedObject = GameObject.Find("Player");
        }
        weapon = GameObject.Find("stick");
        animator = weapon.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(transform.position, attackedObject.transform.position);
        isPlaying = animator.GetCurrentAnimatorStateInfo(0).IsName("attack");
        if (distance < 10.0f)
        {
            if (!isPlaying)
            {
                animator.Play("attack", -1, 0f);
            }
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
            {
                Target t = attackedObject.GetComponent<Target>();
                if (t != null)
                {
                    t.playerTakeDamage(damage);
                    Debug.Log("Pozostałe życie: " + t.health);
                }
                animator.Play("empty");
            }
        }
        else
        {
            animator.Play("empty");
        }
    }


}
