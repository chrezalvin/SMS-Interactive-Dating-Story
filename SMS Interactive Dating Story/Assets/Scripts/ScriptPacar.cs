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

    private int amountOfFood = 0;
    private float time = 0f;

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

        if (currentHeart >= maxHeart)
        {
            // game over
            uiController.GotoGoodEnding();
        }
    }

    public void ReduceHeart(float amount)
    {
        currentHeart -= amount;
        currentHeart = Mathf.Clamp(currentHeart, 0f, maxHeart);
        uiController.UpdateHeartDisplay(currentHeart, maxHeart);

        if(currentHeart <= 0f)
        {
            // game over
            uiController.GotoBadEnding();
        }
    }

    public float GetHeart()
    {
        return currentHeart;
    }

    public void EatFood()
    {
        if(amountOfFood >= 3)
            ReduceHeart(10f);
        else
            IncreaseHeart(10f);

        ++amountOfFood;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("zombie"))
        {
            ReduceHeart(10f);
        }
    }
}
