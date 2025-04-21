using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowScoreTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    ScoreTooltip scoreTooltip;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowScoreTooltipUI(true, eventData.position);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ShowScoreTooltipUI(false);
    }

    private void OnDisable()
    {
        ShowScoreTooltipUI(false);
    }

    void ShowScoreTooltipUI(bool show)
    {
        ShowScoreTooltipUI(show, Vector2.zero);
    }

    void ShowScoreTooltipUI(bool show, Vector2 pos)
    {
        if (scoreTooltip.IsUnityNull())
        {
            scoreTooltip = FindAnyObjectByType<ScoreTooltip>();
            if (scoreTooltip.IsUnityNull())
                return;
        }
        if(show)
        {
            scoreTooltip.transform.position = pos;
        }
        scoreTooltip.Show(show);
    }
}
