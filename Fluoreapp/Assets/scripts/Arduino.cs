using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

 

public class Arduino : MonoBehaviour
{
    public bool pc;
    public KeyCode key;
    public player playerScript;
    public DenteSujo denteSujo;
    SerialPort serialPort;
    string message;

    void Start()
    {
        if (!pc) //Esse modo teoricamente funciona somente com o arduino
        {
            serialPort = new SerialPort("COM1", 9600);
            serialPort.Open();

            serialPort.Write("I");
        }
    }



    void Update()
    {

        if (pc) //para selecionar o modo pc ou arduino, basta trocar a bool no inspector como true ou false
        {
            //Esse modo funciona somente para testes em pc
            if (Input.GetKey(key))

            {
                playerScript.TriggerAttack();
                denteSujo.escovando = true;
            }
            else
            {
                denteSujo.escovando = false;

            }
            //Esse modo funciona somente para testes em pc
        }
        else
        {
            //Esse modo teoricamente funciona somente com o arduino
            if (serialPort != null && serialPort.IsOpen)
            {
                message = serialPort.ReadLine();
                Debug.Log(message);
            }

            if (message == "A")
            {
                playerScript.TriggerAttack();
                denteSujo.escovando = true;
                //Mexe
            }
            else if (message == "P")
            {
                denteSujo.escovando = false;
                //Parado
            }
            //Esse modo teoricamente funciona somente com o arduino
        }





    }
}

