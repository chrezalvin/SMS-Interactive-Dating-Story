using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueDisplayer : MonoBehaviour
{
    [SerializeField] private AudioClip dialogueSound;

    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI dialogueLabel;

    public void PlayDialogue(DialogueObject dialogueObject)
    {
        if(!dialogueBox.activeSelf)
            DisplayDialogur(dialogueObject);
    }    
    
    public void PlayDialogue(DialogueLine[] dialogueLines)
    {
        if(!dialogueBox.activeSelf)
            DisplayDialogur(dialogueLines);
    }

    // dialogue object and callback
    public IEnumerator Dialogue(DialogueObject dialogueObject, Action<DialogueLine> callback)
    {
        for (int iii = 0; iii < dialogueObject.dialogueLines.Length; ++iii)
        {
            dialogueText.text = dialogueObject.dialogueLines[iii].dialogue;
            dialogueLabel.text = dialogueObject.dialogueLines[iii].name;

            callback.Invoke(dialogueObject.dialogueLines[iii]);

            yield return new WaitUntil(() => Input.GetMouseButtonDown(1));

            // play audio
            AudioSource.PlayClipAtPoint(dialogueSound, Camera.main.transform.position);

            yield return null;
        }

        dialogueBox.SetActive(false);
    }

    public IEnumerator Dialogue(DialogueLine[] dialogueLines, Action<DialogueLine> callback)
    {
        for (int iii = 0; iii < dialogueLines.Length; ++iii)
        {
            dialogueText.text = dialogueLines[iii].dialogue;
            dialogueLabel.text = dialogueLines[iii].name;

            callback.Invoke(dialogueLines[iii]);

            yield return new WaitUntil(() => Input.GetMouseButtonDown(1));

            // play audio
            AudioSource.PlayClipAtPoint(dialogueSound, Camera.main.transform.position);

            yield return null;
        }

        dialogueBox.SetActive(false);
    }

    private IEnumerator MoveThroughDialogue(DialogueObject dialogueObject)
    {
        for(int iii = 0; iii < dialogueObject.dialogueLines.Length; ++iii)
        {
            dialogueText.text = dialogueObject.dialogueLines[iii].dialogue;
            dialogueLabel.text = dialogueObject.dialogueLines[iii].name;

            yield return new WaitUntil(() => Input.GetMouseButtonDown(1));
            
            // play audio
            AudioSource.PlayClipAtPoint(dialogueSound, Camera.main.transform.position);

            yield return null;
        }

        dialogueBox.SetActive(false);
    }    
    
    private IEnumerator MoveThroughDialogue(DialogueLine[] dialogueLines)
    {
        for(int iii = 0; iii < dialogueLines.Length; ++iii)
        {
            dialogueText.text = dialogueLines[iii].dialogue;
            dialogueLabel.text = dialogueLines[iii].name;

            yield return new WaitUntil(() => Input.GetMouseButtonDown(1));
            
            // play audio
            AudioSource.PlayClipAtPoint(dialogueSound, Camera.main.transform.position);

            yield return null;
        }

        dialogueBox.SetActive(false);
    }

    public void DisplayDialogur(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(MoveThroughDialogue(dialogueObject));
    }    
    
    public void DisplayDialogur(DialogueLine[] dialogueLines)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(MoveThroughDialogue(dialogueLines));
    }
}
