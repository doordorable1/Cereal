using UnityEngine;

public class ScoreTooltip : MonoBehaviour
{
    CanvasGroup m_canvasGroup;
    public void Show(bool show) => m_canvasGroup.alpha = (show) ? 1f : 0f;

    private void Awake()
    {
        m_canvasGroup = GetComponent<CanvasGroup>();

        Show(false);
    }
}
