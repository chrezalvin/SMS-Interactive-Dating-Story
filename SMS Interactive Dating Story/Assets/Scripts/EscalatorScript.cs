using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EscalatorScript : MonoBehaviour
{
    public GameObject player;
    private bool isLevitating = false;

    private Animator animator;

    private bool ToggleLevitation()
    {
        isLevitating = !isLevitating;
        return isLevitating;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //player.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
                
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // make player child of escalator
            collision.transform.SetParent(transform, true);
            collision.transform.localScale = new Vector3(1/transform.localScale.x, 1/transform.localScale.y, 1/transform.localScale.z);

            //player.transform.parent = this.transform;
            //player.transform.SetParent(transform, false);

            animator.SetBool("isLevitating", ToggleLevitation());
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.transform.localScale = new Vector3(1 / transform.localScale.x, 1 / transform.localScale.y, 1 / transform.localScale.z);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            // make player no longer child of escalator
            player.transform.SetParent(null, false);
            //player.transform.parent = null;
        }
    }
}
