using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	private BallManager ballManager;
	private bool alreadyScored;


    private void Start()
    {
		ballManager = GameObject.FindObjectOfType<BallManager>();
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
