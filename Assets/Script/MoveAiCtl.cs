using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAiCtl : MonoBehaviour
{
    [SerializeField] private Transform aPos;
    [SerializeField] private Transform bPos;
    [SerializeField] private float speed;
   
    private Vector3 target;
    
    // Start is called before the first frame update
    void Start()
    {
        //set diem dau diem cuoi
        transform.position = aPos.position;
        target = bPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, aPos.position) < 0.001f)
        {
            target = bPos.position;
        }     
        else if(Vector3.Distance(transform.position, bPos.position) < 0.001f)
        {
            target = aPos.position;
        }
    }
}
