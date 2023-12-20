using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public int mainMenuSceneIndex = 0;
    public AudioClip hoverSound = null;
    public AudioClip okaySound = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayHoverSound()
    {
        if (hoverSound != null)
        {
            AudioSource.PlayClipAtPoint(hoverSound, Camera.main.transform.position);
        }
    }

    public void PlayOkaySound()
    {
        if (okaySound != null)
        {
            AudioSource.PlayClipAtPoint(okaySound, Camera.main.transform.position);
        }
    }

    public void GotoScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetSomethingActive(GameObject something)
    {
        something.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
