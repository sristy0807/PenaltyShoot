﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputControl : MonoBehaviour
{
	private BallManager ballManager;

	private Vector2 startPos;  
	private Vector2 endPos;    
	private Vector2 direction; 

	private float touchTimeStart; 
	private float touchTimeFinish;
	private float timeInterval;

	public float throwForceInXandY = 1f; //force multiplier for x and y axes

	public float throwForceInZ = 50f;    //force multiplier for z axis

	public float speed = 20;

<<<<<<< Updated upstream
	private bool tapped;
=======
	private bool tapped;	//check if current ball is tapped
	private float SWIPE_THRESHOLD = 20f; //minimum swipe value
>>>>>>> Stashed changes

	Rigidbody rb;   //rigidbody reference of the ball
	
	

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		ballManager = GameObject.FindObjectOfType<BallManager>();
	}

    private void OnDestroy()
    {
		GameManager.instance.GetNewBall();
    }

    // Update is called once per frame
    void Update()
	{
		if (tapped)
        {
			return;
        }

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			touchTimeStart = Time.time;
			startPos = Input.GetTouch(0).position;
		}


		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
		{

			// Check if finger is over a UI element
			if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
			{
				return;
			}


			touchTimeFinish = Time.time;

			timeInterval = touchTimeFinish - touchTimeStart;

			endPos = Input.GetTouch(0).position;

			//direction = startPos - endPos;
			direction = startPos - endPos;

			rb.isKinematic = false;

			throwForceInZ += Time.deltaTime;
			
			rb.AddForce(new Vector3(-direction.x * throwForceInXandY, -direction.y * throwForceInXandY, throwForceInZ * speed / timeInterval));
			//TestUI.forceVal = new Vector3(-direction.x * throwForceInXandY, -direction.y * throwForceInXandY, throwForceInZ * speed / timeInterval);
			ballManager.DeductBallTurn();
			tapped = true;
			Destroy(gameObject, 4f);

		}

	}


}
<<<<<<< Updated upstream
=======
















>>>>>>> Stashed changes
