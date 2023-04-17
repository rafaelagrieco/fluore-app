using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoIniciar : MonoBehaviour
{
    public void IrParaOutraCena()
    {
        SceneManager.LoadScene("home");
    }
}
