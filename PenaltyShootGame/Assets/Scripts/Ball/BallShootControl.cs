using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShootControl : MonoBehaviour
{
   
    public void ShooTheBall(Vector3 forceVector, Rigidbody rigidbody)
    {
        rigidbody.isKinematic = false;
        rigidbody.AddForce(forceVector, ForceMode.Impulse);
    }
    

}
