using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnClickOpenDialogue : MonoBehaviour
{
    [SerializeField] private DialogueObject dialogue;
    public DialogueDisplayer dialogueDisplayer;

    public UnityEvent onClick;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onClick.Invoke();
            dialogueDisplayer.PlayDialogue(dialogue);
        }
    }
}
