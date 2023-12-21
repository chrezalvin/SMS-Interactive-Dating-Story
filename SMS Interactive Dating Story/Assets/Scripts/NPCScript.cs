using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// must have animator
[RequireComponent(typeof(Animator))]
public class NPCScript : MonoBehaviour
{
    private Animator animator;

    public string npcName = "";
    public DialogueObject dialogueObject;
    public DialogueDisplayer dialogueDisplayer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dialogueDisplayer.PlayDialogue(dialogueObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // highlight this cube
            Debug.Log("Player entered NPC trigger");

        }
    }
}
