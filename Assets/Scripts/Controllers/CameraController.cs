using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;  // Reference to the player.
    public Vector3 offset;    // Offset of the camera. Adjust camera position.

    public float pitch = 2f;       // Look at the player little bit higher.
    public float yawSpeed = 100f;
    private float currentYaw = 0f;

    private float currentZoom = 10f;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    private void Update() 
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom); // Zoom can't be lower than minZoom and higher than maxZoom.
        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    private void LateUpdate() 
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
