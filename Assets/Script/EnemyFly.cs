using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    [SerializeField] private float timeCheck;

    private Rigidbody body;
    private void Start()
    {        
        body = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().useGravity = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad > timeCheck)
        {
            body.useGravity = true;
        }
    }
}
