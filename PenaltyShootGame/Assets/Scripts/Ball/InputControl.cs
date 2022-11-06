using System.Collections;
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

	private bool tapped;
	private float SWIPE_THRESHOLD = 20f;



	// Update is called once per frame
	void Update()
	{
#if UNITY_ANDROID && !UNITY_EDITOR
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
				tapped = true;
				EventManager.ShotTaken(direction, timeInterval);
			}
			

		}
#elif UNITY_EDITOR

		if (Input.GetMouseButton(0))
        {
            touchTimeStart = Time.time;
            startPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
           

            touchTimeFinish = Time.time;

            timeInterval = touchTimeFinish - touchTimeStart;

            endPos = Input.mousePosition;

            //direction = startPos - endPos;
            direction = startPos - endPos;
			EventManager.ShotTaken(direction, timeInterval);
            
        }
    
#endif
	}

	private float VerticalMoveValue()
    {
        return (endPos.y - startPos.y);
    }

    private float HorizontalMoveValue()
    {
        return Mathf.Abs(startPos.x - endPos.x);
    }

}







