using UnityEngine;
using UnityEngine.Splines.ExtrusionShapes;
using UnityEngine.UI;

public class CloseCanvas : MonoBehaviour
{
    Button button;
    void Start()
    {
        button = GetComponent<Button>();
        Debug.Log(button.name);
        button.onClick.AddListener(Close);
    }

    public void Close()
    {
        Debug.Log("Close()");
        GetComponentInParent<Canvas>().enabled = false;
    }
}
