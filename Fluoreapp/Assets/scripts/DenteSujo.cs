using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DenteSujo : MonoBehaviour
{

    public float TempoEscovando = 120;
    public SpriteRenderer sprite;
    public SpriteRenderer sprite2;
    public bool escovando;

    [HideInInspector] public bool clean;

    private float m_TempoEscovando;
    private float m_timer;
    private Color cor;

    void Start()
    {
        m_TempoEscovando = TempoEscovando;
        cor = new Color(1, 1, 1);
    }


    void Update()
    {
        if (escovando && TempoEscovando > 0)
        {
            TempoEscovando -= Time.deltaTime;

            cor.a = TempoEscovando / m_TempoEscovando;
            sprite.color = cor;
            sprite2.color = cor;
        }
        else if (TempoEscovando <= 0)
        {
            cor.a = 0;
            clean = true;
            //CABOU
        } 

    }

}
