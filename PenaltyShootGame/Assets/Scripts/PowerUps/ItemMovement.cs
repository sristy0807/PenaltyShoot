using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemMovement : MonoBehaviour
{


    public void MoveObjectHorizontally(float endPoint, float duration)
    {
        transform.DOMoveX(endPoint, duration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);

    }


}
