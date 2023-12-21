using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatDialogueSet : MonoBehaviour
{
    public TextMeshProUGUI text;

    public AudioClip chatPopSound = null;

    // Start is called before the first frame update
    void Start()
    {     

        if (chatPopSound != null)
        {
            AudioSource.PlayClipAtPoint(chatPopSound, Camera.main.transform.position);
        }
    }

    public void SetDialogue(string dialogue)
    {
        text.text = dialogue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
