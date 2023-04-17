using UnityEngine;
using UnityEngine.UI;

public class BotaoProximoObjeto : MonoBehaviour
{
    public GameObject nextObject;

    private void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(NextObject);
    }

    private void NextObject()
    {
        nextObject.SetActive(false);
        gameObject.SetActive(false);
    }
}




