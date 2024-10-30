using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1_Follow : MonoBehaviour
{
  
    public Transform FollowTarget;
    public float distance = 5f;
    public float min = -45f;
    public float max = 45f;
    private float rotationX = 0f;
    private float rotationY = 0f;
    public Vector3 offset;

    // Planar rotation (Y-axis only)
    public Quaternion planareRotation => Quaternion.Euler(0, rotationY, 0);

    private void Update()
    {
        rotationX -= Input.GetAxis("Mouse Y");
        rotationX = Mathf.Clamp(rotationX, min, max);

        rotationY += Input.GetAxis("Mouse X");

        var focusPosition = FollowTarget.position + offset;

        // Use planar rotation (Y-axis rotation only) for the horizontal rotation
        transform.position = focusPosition - planareRotation * new Vector3(0, 0, distance);

        // Look at the focus position while applying the full X and Y rotation
        transform.LookAt(focusPosition);
    }
}
