using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KhienRotateCtl : MonoBehaviour
{
    [SerializeField] [Range(0f, 3f)] private float rotateY;
   
    private void Update()
    {
        transform.Rotate(0, rotateY, 0);
    }
}
