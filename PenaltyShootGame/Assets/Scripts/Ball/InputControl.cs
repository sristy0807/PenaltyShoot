using System.Collections;
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



//{

//	#region from previous code
//	public float speed = 20;

//	private bool tapped;

//	Rigidbody rb;
//	#endregion
//	private Vector2 fingerDownPos;
//	private Vector2 fingerUpPos;

//	public bool detectSwipeAfterRelease = false;

//	public float SWIPE_THRESHOLD = 20f;

//	// Update is called once per frame
//	void Update()
//	{

//		foreach (Touch touch in Input.touches)
//		{
//			if (touch.phase == TouchPhase.Began)
//			{
//				fingerUpPos = touch.position;
//				fingerDownPos = touch.position;
//				touchTimeStart = Time.time;
//			}

//			//Detects Swipe while finger is still moving on screen
//			if (touch.phase == TouchPhase.Moved)
//			{
//				if (!detectSwipeAfterRelease)
//				{
//					fingerDownPos = touch.position;
//					DetectSwipe();
//				}
//			}

//			//Detects swipe after finger is released from screen
//			if (touch.phase == TouchPhase.Ended)
//			{
//				fingerDownPos = touch.position;
//				DetectSwipe();
//			}
//		}
//	}

//	void DetectSwipe()
//	{

//		if (VerticalMoveValue() > SWIPE_THRESHOLD && HorizontalMoveValue() > SWIPE_THRESHOLD)
//		{

//			direction = startPos - endPos;
//		}
//		else
//		{
//			Debug.Log("No Swipe Detected!");
//		}
//	}

//	float VerticalMoveValue()
//	{
//		return Mathf.Abs(fingerDownPos.y - fingerUpPos.y);
//	}

//	float HorizontalMoveValue()
//	{
//		return Mathf.Abs(fingerDownPos.x - fingerUpPos.x);
//	}

//	void OnSwipeUp()
//	{
//		//Do something when swiped up
//	}

//	void OnSwipeDown()
//	{
//		//Do something when swiped down
//	}

//	void OnSwipeLeft()
//	{

//	}

//	void OnSwipeRight()
//	{

//	}
//}













