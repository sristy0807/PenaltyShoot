using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


/// <summary>
/// this class is responsible for a dotween movement
/// </summary>
public class ItemMovement : MonoBehaviour
{

    //take the endpoint and duration for the horizontal movement loop

    public void MoveObjectHorizontally(float endPoint, float duration)
    {
        transform.DOMoveX(endPoint, duration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);

    }


}
