using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Card card;
    TempletTooltip templetTooltip;

    void Awake()
    {
        card = GetComponentInChildren<Card>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowTooltipUI(true, eventData.position);
        templetTooltip?.SetData(card.cardTemplate.cardInfo);

        //Debug.Log("OnPointerEnter");
        //Debug.Log(eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ShowTooltipUI(false);
        //Debug.Log("OnPointerExit");
        //Debug.Log(eventData);
    }

    void SetPosition(Vector2 mousePosition)
    {
        float halfWidth = Screen.width / 2f;
        float halfHeight = Screen.height / 2f;

        templetTooltip.transform.position = mousePosition;
    }

    void ShowTooltipUI(bool show)
    {
        ShowTooltipUI(show, Vector2.zero);
    }

    void ShowTooltipUI(bool show, Vector2 pos)
    {
        if (templetTooltip.IsUnityNull())
        {
            templetTooltip = FindAnyObjectByType<TempletTooltip>();
            if (templetTooltip.IsUnityNull())
                return;
        }
        if (show)
        {
            SetPosition(pos);
        }
        templetTooltip.Show(show);
    }

    private void OnDisable()
    {
        ShowTooltipUI(false);
    }

    public bool testShow;
    public Vector2 testPos;
    [ContextMenu("ShowTooltipUI(testShow, testPos)")]
    void TestShowTooltipUI()
    {
        ShowTooltipUI(testShow, testPos);
    }
}
