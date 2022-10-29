using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUI : MonoBehaviour
{

    public Text forceX, forceY, forceZ;

    public static Vector3 forceVal;


    
        
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forceX.text = "x: " + forceVal.x;
        forceX.text = "y: " + forceVal.y;
        forceX.text = "z: " + forceVal.z;

    }
}
