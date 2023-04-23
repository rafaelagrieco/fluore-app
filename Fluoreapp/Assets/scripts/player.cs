using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public float attackRange;
    public int damage;
    private Animator anim;

    public AudioSource ataqueSFX; 
    public AudioSource medoSFX;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();



    }

    void Update()
    {
        if(timeBtwAttack <= 0)
        {
            //if (Input.GetKey(KeyCode.Space))
            //{
            //    anim.SetTrigger("Ataque");
            //}
        }
        else
        {
            timeBtwAttack -= Time.deltaTime; 
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    public void TriggerAttack()
    {
        if (timeBtwAttack <= 0)
        {
            anim.SetTrigger("Ataque");
            timeBtwAttack = startTimeBtwAttack;

            ataqueSFX.Play();

        }
       

    }
    public void ScaredSound()
    {
        medoSFX.Play();

        


    }

    public void Attack()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<enemy>().TakeDamage(damage);
        }
    }
}
