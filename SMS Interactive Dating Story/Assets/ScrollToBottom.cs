using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollToBottom : MonoBehaviour
{
    public ScrollRect scrollRect;
    public DialogueObject dialogs;

    public GameObject chatPrefabLeft;
    public GameObject chatPrefabRight;
    public GameObject chatPrefabSpecial;

    public GameObject loadingScreen;
    public AudioClip okayAudio = null;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveThroughDialogue(dialogs));
    }

    GameObject GetChatBasedOnDialogue(DialogueLine dialogueLine)
    {
        if(dialogueLine.animationParam == "special")
        {
            return chatPrefabSpecial;
        }

        if (dialogueLine.name == "Aldo")
        {
            return chatPrefabLeft;
        }
        else
        {
            return chatPrefabRight;
        }
    }

    private IEnumerator MoveThroughDialogue(DialogueObject dialogueObject)
    {
        for (int iii = 0; iii < dialogueObject.dialogueLines.Length; ++iii)
        {
            GameObject chat = GetChatBasedOnDialogue(dialogueObject.dialogueLines[iii]);

            chat.GetComponent<ChatDialogueSet>().SetDialogue(dialogueObject.dialogueLines[iii].dialogue);

            GameObject chatObject = AddChatToScene(chat);

            yield return new WaitUntil(() => Input.GetMouseButtonDown(1));

            yield return null;
        }

        if (okayAudio != null)
        {
            AudioSource.PlayClipAtPoint(okayAudio, Camera.main.transform.position);
        }
        loadingScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject AddChatToScene(GameObject prefab)
    {
        return Instantiate(prefab, scrollRect.content.transform);
    }
}
