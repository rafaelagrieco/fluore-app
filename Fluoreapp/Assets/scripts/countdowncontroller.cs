using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class countdowncontroller : MonoBehaviour
{
    public GameObject hudContainer;
    public float countdownTime;
    public bool gameStart;
    public TextMeshProUGUI countdownDisplay;
    public AudioSource cdwSFX;
    public AudioClip audioClip;

    private void Awake()
    {
      
    }

    private void Update()
    {
        if (gameStart || countdownTime <= 1)
        {
            hudContainer.SetActive(false);
            return;
        }
        else
        {
            countdownTime -= Time.deltaTime;
            countdownDisplay.text = "" + (int)countdownTime;

           
           
        }
        

    }

    
    
}
