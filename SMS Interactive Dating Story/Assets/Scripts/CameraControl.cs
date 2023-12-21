using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform target;
    public bool debug = false;
    public Vector3 m_offset = new Vector3(0, 1, 5);
    public float rotationMultiplier = 1;
    public float zoomMultiplier = 1;

    public float m_baseRotSpeed = 10f;
    public float m_baseZoomSpeed = 10f;

    public float minZoom = 1f;
    public float maxZoom = 10f;

    private Transform refPoint;

    private float zoom = 3f;

    private void Start()
    {
        refPoint = new GameObject().transform;
        refPoint.position = m_offset;
    }

    private void LateUpdate()
    {
        // uses mouse
        float v = Input.GetAxis("Mouse Y");
        float h = Input.GetAxis("Mouse X");
        float z = Input.GetAxis("Mouse ScrollWheel");

        // if mouse pressed then rotate
        if (Input.GetMouseButton(1) && (v != 0 || h != 0))
        {
            refPoint.RotateAround(Vector3.zero, this.transform.up, h * m_baseRotSpeed * rotationMultiplier);
            refPoint.RotateAround(Vector3.zero, this.transform.right, -v * m_baseRotSpeed * rotationMultiplier);

            if (debug)
                Debug.Log("Camera rotated to: " + transform.rotation.eulerAngles);
        }
        if (z != 0)
        {
            zoom = Mathf.Clamp(zoom - z * m_baseZoomSpeed * zoomMultiplier, minZoom, maxZoom);

            if (debug)
                Debug.Log("Camera zoomed to: " + transform.position);
        }

        // if offset is off then re-adjust
        if (m_offset != transform.position - target.position)
        {
            transform.position = target.position + m_offset;
        }

        this.transform.position = target.position + refPoint.position * zoom;

        transform.LookAt(target);
    }
}
