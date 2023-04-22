using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progression : MonoBehaviour
{
    public float delayVitoria;
    public DenteSujo denteSujo;
    public enemy enemies;
    public GameObject vitoria;

    private bool oneTime;
    

    void Start()
    {
        
    }

    void Update()
    {
        if (oneTime)
            return;

        if(denteSujo.clean && enemies.m_dead)
        {
            StartCoroutine(VitoriaCoroutine());
            oneTime = false;
        }
    }

    IEnumerator VitoriaCoroutine()
    {
        yield return new WaitForSeconds(delayVitoria);
        vitoria.SetActive(true);
    }
}
