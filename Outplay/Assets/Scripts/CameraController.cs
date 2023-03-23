using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;  
    public float distance = 10.0f;  
    public float sensitivity = 5.0f;
    public float minY = -20.0f;  
    public float maxY = 80.0f;

    private float currentX = 0.0f;
    private float currentY = 0.0f;

    void LateUpdate()
    {
        //An early out in case there is no target. used when the player is destroyed
        if (!target) return;

        currentX += Input.GetAxis("Mouse X") * sensitivity;
        currentY += Input.GetAxis("Mouse Y") * sensitivity;
        currentY = Mathf.Clamp(currentY, minY, maxY);

        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = target.position - rotation * Vector3.forward * distance;
        transform.rotation = rotation;
    }
}