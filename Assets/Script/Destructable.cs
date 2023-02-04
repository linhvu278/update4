using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    void OnTriggerEnter(Collider collider){
        if (collider.gameObject.tag == "Rocket"){
            CollisionCtl collisionCtl = collider.transform.GetComponent<CollisionCtl>();
            if (collisionCtl.isScaleUp){
                // add destroy sound effect here
                Destroy(gameObject);
            }
        }
    }
}
