using UnityEngine;
using DG.Tweening;

public class ShopPanelAnimation : MonoBehaviour
{
    private float shownYPosition = -2f;     
    private float hiddenYPosition = 3f; 
    private Tweener slideTween;
    
    private float slideDuration = 0.6f;
    private Ease showEase = Ease.OutBack;
    private Ease hideEase = Ease.InBack;
    private RectTransform rectTransform;


    void OnEnable() 
    {
        StartSlideDown();
    }
    

    public void StartSlideDown() 
    {
        slideTween = transform.DOMoveY(shownYPosition, slideDuration)
            .SetEase(showEase);
    }

    public void StartSlideUp()
    {
        slideTween = transform.DOMoveY(hiddenYPosition, slideDuration)
            .SetEase(hideEase);
    }
}
