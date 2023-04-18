using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botaoEscovar : MonoBehaviour
{
    public void IrParaOutraCena()
    {
        SceneManager.LoadScene("jogo");
    }
}
