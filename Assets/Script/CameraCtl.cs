using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtl : MonoBehaviour
{
    private Transform target;
    private Vector3 offset;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<MoveCtl>().transform;
        offset = new Vector3(0, 1, -17);
        speed = 5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, speed * Time.fixedDeltaTime);
    }
}
