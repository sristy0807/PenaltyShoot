using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// this is a componenet for disabling a game object after a fixed time
/// </summary>

public class LimitedLife : MonoBehaviour
{

    public float lifeTime = 3f;

    void OnEnable()
    {
        Invoke("Disable", lifeTime);
    }

    //disable the gameobject when invoked
    private void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
