using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideTeleport : MonoBehaviour
{
    public Transform to;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.position = to.position;
    }
}
