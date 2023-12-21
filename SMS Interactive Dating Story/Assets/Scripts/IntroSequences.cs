using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSequences : MonoBehaviour
{
    public GameObject introText;
    public GameObject introChats;

    private bool introTextActive = true;

    // Start is called before the first frame update
    void Start()
    {
        introText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!introText.activeSelf && introTextActive)
        {
            introChats.SetActive(true);
            introTextActive = false;
        }
    }
}
