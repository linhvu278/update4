using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUp : MonoBehaviour
{
    private BoxCollider boxCollider;
    private float powerupTime = 5f;
    CowndownTime countdown;
    CollisionCtl collisionCtl;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        collisionCtl = CollisionCtl.collisionCtl;
        countdown = CowndownTime.cowndownTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Rocket")
        {
            countdown.SetTime(powerupTime);
            collisionCtl.SetPowerupTimer(powerupTime);
            Destroy(gameObject);
        }
    }
}
