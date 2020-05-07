using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YetAnotherSceneManager : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public string sceneName;

    private void Update()
    {
        if(dialogueManager.Completed())
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
