using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class countdowncontroller : MonoBehaviour
{
    public float countdownTime;
    public bool gameStart;
    public TextMeshProUGUI countdownDisplay;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (gameStart || countdownTime <= 1)
        {
            transform.gameObject.SetActive(false);
            return;
        }
        else
        {
            countdownTime -= Time.deltaTime;
            countdownDisplay.text = "" + (int)countdownTime;
        }
       
    }

    
}
