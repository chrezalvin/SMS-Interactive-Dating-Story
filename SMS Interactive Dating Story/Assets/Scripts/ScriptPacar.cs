using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPacar : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private UIController uiController;
    [SerializeField] private Animator animator;
    public float minDistance = 1f;

    [SerializeField] private float maxHeart = 100f;
    [SerializeField] private float currentHeart = 20f;

    // Start is called before the first frame update
    void Start()
    {
        uiController.UpdateHeartDisplay(currentHeart, maxHeart);
    }

    public void IncreaseHeart(float amount)
    {
        currentHeart += amount;
        currentHeart = Mathf.Clamp(currentHeart, 0f, maxHeart);
        uiController.UpdateHeartDisplay(currentHeart, maxHeart);
    }

    public void ReduceHeart(float amount)
    {
        currentHeart -= amount;
        currentHeart = Mathf.Clamp(currentHeart, 0f, maxHeart);
        uiController.UpdateHeartDisplay(currentHeart, maxHeart);

        if(currentHeart <= 0f)
        {
            // game over
            uiController.GameOver();
        }
    }

    public float GetHeart()
    {
        return currentHeart;
    }

    // Update is called once per frame
    void Update()
    {
        // follow xz plane to player, keep distance
        
        float distance = Vector3.Distance(this.transform.position, player.position);

        animator.SetBool("isWalk", distance > minDistance);
        if ( distance > minDistance)
        {
            this.transform.Translate(this.transform.forward * Time.deltaTime, Space.World);

            // face player
            Vector3 direction = player.position - this.transform.position;
            this.transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
