using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerGeral : MonoBehaviour
{
    public float timer = 120;
    public Color corAzul;
    public Color corVermelha;
    Animator anim;

    public Material material;

    public Image background;
    public Slider sliderFill;
    float startTime;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        sliderFill.maxValue = timer;
        sliderFill.value = timer;
        startTime = Time.time;
    }

    void Update()
    {
        TimerCount();
        if (sliderFill.value <= 0)
        {
            //finalDeJogo
        }
        else if (sliderFill.value < timer/4)
        {
            anim.SetTrigger("coco");  
        }
        float frac = sliderFill.value/timer;
        background.GetComponent<Image>().color = Color.Lerp(corVermelha, corAzul, frac);
    }

    void TimerCount()
    {
        sliderFill.value -= Time.deltaTime;
       
    }
}
