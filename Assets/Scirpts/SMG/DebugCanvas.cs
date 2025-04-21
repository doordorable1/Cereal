using UnityEngine;
using UnityEngine.EventSystems;

public class DebugCanvas : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
        Debug.Log(eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
        Debug.Log(eventData);
    }

    public void Test(BaseEventData data)
    {
        Debug.Log("Test");
        Debug.Log(data);
    }
    public void Test123()
    {

    }
}
