using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // translate with input
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 5f, 0f, Input.GetAxis("Vertical") * Time.deltaTime * 5f);

        
    }
}
