using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemMovement : MonoBehaviour
{


    public void MoveObject(float endPoint, float duration)
    {
        transform.DOMoveX(endPoint, 1)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);

    }


}
