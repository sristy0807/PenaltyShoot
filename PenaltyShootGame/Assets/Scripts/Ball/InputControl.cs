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

	public float throwForceInXandY = 1f; 

	public float throwForceInZ = 50f;

	public float speed
    {
        get
        {
			return GameManager.instance.speed;
        }
    }

	private bool tapped;
	private float SWIPE_THRESHOLD = 20f;

	Rigidbody rb;
	
	

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

			if(VerticalMoveValue()>SWIPE_THRESHOLD && HorizontalMoveValue() > SWIPE_THRESHOLD)
            {
				direction = startPos - endPos;
				rb.isKinematic = false;
				throwForceInZ += Time.deltaTime;
				rb.AddForce(new Vector3(-direction.x * throwForceInXandY, -direction.y * throwForceInXandY, throwForceInZ * speed / timeInterval));
				ballManager.DeductBallTurn();
				tapped = true;
				Destroy(gameObject, 4f);
			}
			

		}

	}

    float VerticalMoveValue()
    {
        return (endPos.y - startPos.y);
    }

    float HorizontalMoveValue()
    {
        return Mathf.Abs(startPos.x - endPos.x);
    }

}







