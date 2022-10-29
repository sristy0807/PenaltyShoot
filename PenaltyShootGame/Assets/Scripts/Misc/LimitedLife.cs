using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedLife : MonoBehaviour
{

    public float lifeTime = 3f;

    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke("Disable", lifeTime);
    }

    private void Disable()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
