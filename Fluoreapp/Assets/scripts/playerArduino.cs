using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class playerArduino : MonoBehaviour
{

    SerialPort serialPort;
    string message;

    void Start()
    {
        serialPort = new SerialPort("COM3", 9600);
        serialPort.Open();
    }

    void Update()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            message = serialPort.ReadLine();
            Debug.Log(message);
        }

    }
}