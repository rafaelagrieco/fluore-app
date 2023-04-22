using UnityEngine;
using UnityEngine.SceneManagement;

public class voltarInventario : MonoBehaviour
{
    public void IrParaOutraCena()
    {
        SceneManager.LoadScene("home");
    }
}

