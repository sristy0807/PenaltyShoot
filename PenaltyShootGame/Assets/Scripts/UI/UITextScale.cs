using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UITextScale : MonoBehaviour
{
    RectTransform rectTransform;

    [SerializeField] private Vector3 targetScale;
    [SerializeField] private float duration;
    [SerializeField] private bool infiniteLoop;

    private void OnEnable()
    {
        SetScaleAnimation();
    }

    private void SetScaleAnimation()
    {
        if (infiniteLoop)
        {
            rectTransform = GetComponent<RectTransform>();
            rectTransform.DOScale(targetScale, duration)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.Linear);
        }
        else
        {
            rectTransform = GetComponent<RectTransform>();
            rectTransform.DOScale(targetScale, duration)
                .SetLoops(2, LoopType.Yoyo)
                .SetEase(Ease.Linear);
        }
        
    }
}
