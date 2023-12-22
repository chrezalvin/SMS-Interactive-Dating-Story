using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// must have animator
[RequireComponent(typeof(Animator))]
public class NPCScript2 : MonoBehaviour
{
    private Animator animator;

    public string npcName = "";
    public DialogueLine[] dialogueLines;
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
            Debug.Log("Player clicked NPC");
            StartCoroutine(dialogueDisplayer.Dialogue(dialogueLines, (dialogueLine) =>
            {
                Debug.Log("Playing animation: " + dialogueLine.animationParam);
                animator.SetTrigger(dialogueLine.animationParam);
            }));
            dialogueDisplayer.PlayDialogue(dialogueLines);
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
