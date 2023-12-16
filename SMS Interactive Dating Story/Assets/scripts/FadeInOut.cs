using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;

    public bool fade = false;
    public float interval = 0.5f;

    private void toggleFade()
    {
        fade = !fade;
    }

    private void Update()
    {
        if (fade)
        {
            if(canvasGroup.alpha >= 0.01f)
                canvasGroup.alpha -= Time.deltaTime / interval;
            else
                toggleFade();
                
        }
        else
        {
            if(canvasGroup.alpha <= 0.99f)
                canvasGroup.alpha += Time.deltaTime / interval;
            else
                toggleFade();
        }
    }
}
