using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform target;
    public bool debug = false;

    float rotationMultiplier = 1;
    float zoomMultiplier = 1;

    private float m_baseRotSpeed = 10f;
    private float m_baseZoomSpeed = 10f;
    public Vector3 m_offset = new Vector3(0, 1, -5);

    private void Start()
    {
        m_offset = transform.position - target.position;
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
            transform.RotateAround(target.position, Vector3.up, h * m_baseRotSpeed * rotationMultiplier);
            transform.RotateAround(target.position, Vector3.left, v * m_baseRotSpeed * rotationMultiplier);

            // set a new offset
            m_offset = transform.position - target.position;

            if (debug)
                Debug.Log("Camera rotated to: " + transform.rotation.eulerAngles);
        }
        if (z != 0)
        {
            transform.Translate(Vector3.forward * z * m_baseZoomSpeed * zoomMultiplier);

            // set a new offset
            m_offset = transform.position - target.position;

            if (debug)
                Debug.Log("Camera zoomed to: " + transform.position);
        }

        // if offset is off then re-adjust
        if (m_offset != transform.position - target.position)
        {
            transform.position = target.position + m_offset;
        }

        transform.LookAt(target);
    }
}
