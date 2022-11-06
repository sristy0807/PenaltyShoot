using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSlider : MonoBehaviour
{
    public Slider slider;
    public Text value;

    public bool xy;

    InputControl inputManager;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        inputManager = GameObject.FindObjectOfType<InputControl>();
        Debug.Log("test slider");
    }

    // Update is called once per frame
    void Update()
    {
        value.text = slider.value.ToString();
        if (xy)
        {
            //inputManager.throwForceInXandY = slider.value;
        }
        else
        {
            //inputManager.throwForceInZ = slider.value;
        }
    }
}
