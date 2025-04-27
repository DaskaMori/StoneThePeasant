using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Mouse sensitivity
    public float sensitivityX = 2.0f;
    public float sensitivityY = 2.0f;

    // Clamping the vertical rotation so the camera doesn't flip upside down
    public float minimumY = -60f;
    public float maximumY = 60f;

    private float rotationX = 0f;

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY;

        // Rotate the camera on the Y axis (left/right) 
        transform.Rotate(0, mouseX, 0);

        // Adjust the vertical rotation (up/down) and clamp it
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minimumY, maximumY);

        // Apply the vertical rotation
        if (Camera.main != null) Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}
