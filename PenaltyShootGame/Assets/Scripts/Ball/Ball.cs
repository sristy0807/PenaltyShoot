using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Ball : MonoBehaviour
{
	public static event Action<int> OnScored;
	public static event Action OnMissed;

	private bool alreadyScored;


    private void Start()
    {

	}


    private void OnCollisionEnter(Collision collision)
	{
		
	}

	private void Scored()
    {
		ScoreManager.instance.AddNormalGoal();
		
	}

	private void ScoredWithBonus(PowerUpBehavior powerUpBehavior)
	{
		powerUpBehavior.ApplyPowerUpCollisionResult();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Goal")
		{
			if (!alreadyScored)
			{
				Scored();
			}
		}

		if (other.gameObject.CompareTag("PowerUp"))
        {
			alreadyScored = true;
			ScoredWithBonus(other.gameObject.GetComponent<PowerUpBehavior>());
		}
	}
}
