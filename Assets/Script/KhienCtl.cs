using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KhienCtl : MonoBehaviour
{
    private float powerupTime = 5f;
    private BoxCollider boxCollider;
    CollisionCtl collisionCtl;
    CowndownTime countdown;
    
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        collisionCtl = CollisionCtl.collisionCtl;
        countdown = GameObject.FindGameObjectWithTag("GameController").GetComponent<CowndownTime>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Rocket")
        {
            countdown.SetTime(powerupTime);
            collisionCtl.SetPowerupTimer(powerupTime);
            Destroy(gameObject);
        }
    }

}
