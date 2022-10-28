﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputControl : MonoBehaviour
{

	private Vector2 startPos;
	private Vector2 endPos;
	private Vector2 direction;

	private float touchTimeStart; 
	private float touchTimeFinish;
	private float timeInterval;

	public float throwForceInXandY = 1f; 

	public float throwForceInZ = 50f;

	public float speed = 20;

	Rigidbody rb;

	

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		Debug.Log("swipe script");
	}

	// Update is called once per frame
	void Update()
	{

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
			rb.AddForce(new Vector3(-direction.x * throwForceInXandY, -direction.y * throwForceInXandY, throwForceInZ / timeInterval)*speed);

			//Destroy (gameObject, 6f);

		}

	}


}