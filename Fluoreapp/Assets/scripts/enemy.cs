using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health;

    Animator anim;
    

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if( health <= 0)
        {
            anim.SetTrigger("Die");
        }
        else if( health == 1)
        {
            anim.SetTrigger("Cansado");
        }

    }

    public void Die()
    {
        transform.gameObject.SetActive(false);
    }
}
