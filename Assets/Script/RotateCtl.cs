using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCtl : MonoBehaviour
{
    [SerializeField] private float rotateZ;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateZ, 0);
    }
}
