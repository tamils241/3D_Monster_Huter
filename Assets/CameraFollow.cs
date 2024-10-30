using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // The target object for the camera to follow (e.g., player)
    public Vector3 offset;         // Offset distance between the target and camera
    public float followSpeed = 5f; // Speed at which the camera follows the target

    void Start()
    {
        // Initialize the offset by subtracting the target position from the camera position
        if (target != null)
        {
            offset = transform.position - target.position;
        }
    }

    void LateUpdate()
    {
        // Ensure the target is not null
        if (target != null)
        {
            // Calculate the desired position based on the target position and offset
            Vector3 desiredPosition = target.position + offset;

            // Smoothly interpolate between the current position and the desired position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        }
    }

   
}

