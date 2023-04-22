using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health;
    public float timerToSpawn;
    public SpriteRenderer enemies;
    public SpriteRenderer enemiesShadow;

    public bool m_dead;
    private int m_health;
    Animator anim;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        m_health = health;
        
    }

    public void TakeDamage(int damage)
    {
        if (m_dead)
            return;

        health -= damage;

        if( health <= 0)
        {
            m_dead = true;
            anim.SetTrigger("Die");
        }
        else if( health == 1)
        {
            anim.SetTrigger("Cansado");
        }

    }

    public void Die()
    {
        enemies.enabled = false;
        enemiesShadow.enabled = false;

        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(timerToSpawn);
        enemies.enabled = true;
        enemiesShadow.enabled = true;
        health = m_health;

        if(m_dead) anim.SetTrigger("Respawn");
        m_dead = false;
    }
}
