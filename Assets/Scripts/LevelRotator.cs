using System;
using UnityEngine;
public class RotateObjectController : MonoBehaviour
{
    public float horizontalSpeed = 10f;
    public float verticalSpeed = 10f;
    //Drag the camera object here
    public Camera cam;
    
    void FixedUpdate()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        Debug.Log(h);
        transform.Rotate(h, v, 0);
    }
    
}
