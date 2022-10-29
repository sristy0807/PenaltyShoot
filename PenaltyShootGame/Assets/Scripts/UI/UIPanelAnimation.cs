using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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