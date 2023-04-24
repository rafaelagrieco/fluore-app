using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports; //biblioteca arduino


//pelo amor vê o que tá errado nesse código

public class arduinoTikki : MonoBehaviour
{
    SerialPort serialPort;
    string message;

    void Start()
    {//Esse modo teoricamente funciona somente com o arduino
        serialPort = new SerialPort("COM3", 9600);
        serialPort.Open();

        serialPort.Write("I");
    }

    void Update()
    {

        if (serialPort != null && serialPort.IsOpen)
        {
            message = serialPort.ReadLine();
        }

        if (message == "A")
        {
            string atacar = "atacar";
            Debug.Log(atacar);
            serialPort.Write(atacar);
        }
        else if (message == "P")
        {
            string parar = "parado";
            Debug.Log(parar);
            serialPort.Write(parar);
        }
    }

}
