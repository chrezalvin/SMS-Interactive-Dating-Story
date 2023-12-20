using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickOpenDialogue : MonoBehaviour
{
    [SerializeField] private DialogueObject dialogue;
    public DialogueDisplayer dialogueDisplayer;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dialogueDisplayer.PlayDialogue(dialogue);
        }
    }
}
