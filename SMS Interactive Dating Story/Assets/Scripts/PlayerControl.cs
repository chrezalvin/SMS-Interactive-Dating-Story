using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    float speed = 10f;
    float rotationSpeed = 5f;

    public bool debug = false;

    Rigidbody rb;
    public float jumpForce = 10f;
    private bool isGrounded = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        if (v != 0 || h != 0)
        {
            Vector3 NextDir = Quaternion.Euler(0, camera.transform.eulerAngles.y, 0) * new Vector3(h, 0, v);

            if (NextDir != Vector3.zero)
            {
                Quaternion lookrot = Quaternion.LookRotation(NextDir);
                transform.rotation = Quaternion.Slerp(this.transform.rotation, lookrot, rotationSpeed * Time.deltaTime);

                transform.Translate(Time.deltaTime * NextDir * speed, Space.World);
            }
        }

        // raycast if object is touching the ground
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded = Physics.Raycast(transform.position, Vector3.down, out _, 1.1f);
            if (isGrounded)
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
