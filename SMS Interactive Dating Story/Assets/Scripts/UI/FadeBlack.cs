using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeBlack : MonoBehaviour
{
    public float fadeTime = 3.0f;

    public int gotoSceneIndex = 1;
    public CanvasGroup canvasGroup;
    private float alpha = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        canvasGroup.alpha = alpha / 255;

        // if alpha 255
        if (alpha >= 255)
        {
            SceneManager.LoadScene(gotoSceneIndex);
        }

        Debug.Log(alpha);

        alpha += Time.deltaTime * 255 / fadeTime;
    }
}
