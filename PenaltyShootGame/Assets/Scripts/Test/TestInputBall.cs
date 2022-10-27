using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInputBall : MonoBehaviour
{

	private InputControl inputManager;

    public bool isTesting;

	bool shoot;

	Vector2 startPos, endPos, direction; // touch start position, touch end position, swipe direction
	float touchTimeStart, touchTimeFinish, timeInterval; // to calculate swipe time to sontrol throw force in Z direction

	[SerializeField]
	float throwForceInXandY = 1f; // to control throw force in X and Y directions

	[SerializeField]
	float throwForceInZ = 50f; // to control throw force in Z direction

	Rigidbody rb;

	private void Start()
    {
		rb = GetComponent<Rigidbody>();
		inputManager = GetComponent<InputControl>();
    }
    private void Shoot()
    {
		rb.isKinematic = false;
		rb.AddForce(throwForceInXandY, throwForceInXandY, throwForceInZ / timeInterval);

	}


    private void OnMouseDrag()
    {
		Debug.Log("DRAG");    
    }

    float timer = 0;

    private void OnMouseEnter()
    {
        if (timer == 0)
            timer = Time.time;
        Debug.Log(timer + " at start");
    }

    private void OnMouseExit()
    {
        timeInterval = Time.time - timer;
        Debug.Log(timer + " timer");
        shoot = true;
    }

   
    private void Update()
    {
        if (shoot)
        {
			Shoot();
        }
    }

}
