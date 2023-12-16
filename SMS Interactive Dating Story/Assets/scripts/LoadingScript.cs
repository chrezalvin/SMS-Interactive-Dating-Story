using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScript : MonoBehaviour
{
    public GameObject loadingScreen;
    public int waitTime = 2;

    public void LoadScene(Action onSuccess)
    {
        // wait 3 seconds
        StartCoroutine(waitSeconds(waitTime, onSuccess));
    }

    IEnumerator waitSeconds(int seconds, Action onSuccess)
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(seconds);

        onSuccess();
    }
}
