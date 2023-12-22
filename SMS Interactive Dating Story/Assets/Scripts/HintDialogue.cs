using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintDialogue : MonoBehaviour
{
    private Animator animator;

    public string npcName = "";
    public DialogueObject dialogueObject;
    public DialogueDisplayer dialogueDisplayer;

    public AudioClip audioOnDestroy = null;

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
            
            // remove this object
            Destroy(gameObject);
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

    private void OnDestroy()
    {
        // play audio
        if (audioOnDestroy != null)
        {
            AudioSource.PlayClipAtPoint(audioOnDestroy, Camera.main.transform.position);
        }
    }
}
