using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// this class is responsible for a do tween fade in/fade out animtion for a UI object with canvas group
/// </summary>

[RequireComponent(typeof(CanvasGroup))]
public class UIPanelAnimation : MonoBehaviour
{
    [SerializeField] private FadeType fadeType;
    [SerializeField] private float duration;

    private CanvasGroup canvasGroup;


    private void OnEnable()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        FadeAnimation();
    }

    //based on the fade type of the object animation is played
    private void FadeAnimation()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();

        if (fadeType == FadeType.FadeIn)
        {
            canvasGroup.DOFade(1, duration)
                .SetEase(Ease.OutSine);
        }
        else if(fadeType == FadeType.FadeOut)
        {
            canvasGroup.DOFade(0, duration)
                .SetEase(Ease.OutSine);
        }
    }
}


public enum FadeType
{
    FadeIn,FadeOut
}