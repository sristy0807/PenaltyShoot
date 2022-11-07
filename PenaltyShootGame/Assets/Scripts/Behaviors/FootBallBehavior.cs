using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootBallBehavior : MonoBehaviour
{
    public bool alreadyScored { get; private set; }

    public float throwForceInXandY = 1f;
    public float throwForceInZ = 50f;

    private Rigidbody rb;

    [SerializeField] private float speed;
    [SerializeField] private int regularScore;
  
    public void SetBallValues(float _speed, int _regularScore)
    {
        speed = _speed;
        regularScore = _regularScore;
    }

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

    private void OnDestroy()
    {
        EventManager.TakenShotCompleted();
    }

    private void OnShotTheBall(Vector3 direction, float timeInterval)
    {
        rb.isKinematic = false;
        throwForceInZ += Time.deltaTime;
        rb.AddForce(new Vector3(-direction.x * throwForceInXandY, -direction.y * throwForceInXandY, throwForceInZ * speed / timeInterval));
        EventManager.TurnUsed();
        
        Destroy(gameObject, 4f);
    }

}
