using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// this class is responisble for ui text scaling animation
/// </summary>


public class UITextScale : MonoBehaviour
{
    RectTransform rectTransform;

    //animation related fields
    [SerializeField] private Vector3 targetScale; 
    [SerializeField] private float duration;
    [SerializeField] private bool infiniteLoop;

    private void OnEnable()
    {
        SetScaleAnimation();
    }


    //scale animation based on target scale and duration, animation loop determined from object's infiniteloop value otherwise 2loops 
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
