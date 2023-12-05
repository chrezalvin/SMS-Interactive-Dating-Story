using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnEnterTriggerSwitchScene : MonoBehaviour
{
    public int sceneIndex;
    public LoadingScript loadingScript;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            loadingScript.LoadScene(() =>
            {
                SceneManager.LoadScene(sceneIndex);
            });

            // reload the scene
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
