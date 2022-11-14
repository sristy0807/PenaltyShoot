using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

/// <summary>
/// this class provides physics action and collision detection of the player ball 
/// </summary>

public class FootBallBehavior : MonoBehaviour
{
    public bool alreadyScored;

    public float throwForceInXandY = 1f;
    public float throwForceInZ = 50f;

    private Rigidbody rb;

    [SerializeField] private float speed;
    [SerializeField] private int regularScore;


    //assign ball speed and per score when initiated
    public void SetBallValues(float _speed, int _regularScore)
    {
        speed = _speed;
        regularScore = _regularScore;
    }


    #region unity callbacks

    private void OnEnable()
    {
        EventManager.Shot += OnShotTheBall;
    }

    private void OnDisable()
    {
        EventManager.Shot -= OnShotTheBall;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!alreadyScored)
        {
            if (other.gameObject.CompareTag("Goal"))
            {
                EventManager.ScoreUpdate(regularScore);
            }
        }
    }

    //sending notification of completion of current shot
    private void OnDestroy()
    {
        EventManager.TakenShotCompleted();
    }
    #endregion

    // direction of the touch and touch time interval are passed and force is applied to the rigidbody
    private void OnShotTheBall(Vector3 direction, float timeInterval)
    {
        rb.isKinematic = false;
        throwForceInZ += Time.deltaTime;
        rb.AddForce(new Vector3(-direction.x * throwForceInXandY, -direction.y * throwForceInXandY, throwForceInZ / timeInterval)*speed);
        EventManager.TurnUsed();
        
        Destroy(gameObject, 4f);
    }

}
