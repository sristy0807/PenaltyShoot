using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is for the power up items, the items will add or deduct score of the player
/// </summary>

public class ItemBehaviour : MonoBehaviour,IScoreItem
{
    public int scoreValue;
    public bool isIncrementer;


    #region unity callbacks

    private void OnEnable()
    {
        EventManager.ShotComplete += DestroyThisObject;    
    }

    private void OnDisable()
    {
        EventManager.ShotComplete -= DestroyThisObject;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<FootBallBehavior>().alreadyScored = true;
            AddScoreValue(isIncrementer, scoreValue);
        }
    }

    #endregion

    //take the type of the item and the score value and score updates accordingly
    public void AddScoreValue(bool _isIncrementer, int _scoreValue)
    {
        if (_isIncrementer)
        {
            EventManager.BonusScore(_scoreValue);
        }
        else
        {
            EventManager.NegativeScore(_scoreValue);
        }
    }

    //destroy called after each shot
    public void DestroyThisObject()
    {
        Destroy(gameObject);
    }
}
