using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreIncrementerBehavior : MonoBehaviour,IScoreItem
{
    public int scoreValue;
    public bool isIncrementer;

    private void OnEnable()
    {
        EventManager.ShotComplete += DestroyThisObject;    
    }

    private void OnDisable()
    {
        EventManager.ShotComplete -= DestroyThisObject;
    }

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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            AddScoreValue(isIncrementer,scoreValue);
        }
    }

    public void DestroyThisObject()
    {
        Destroy(gameObject);
    }
}
