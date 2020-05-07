using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Scene_Tutorial"))
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Destroy(this.gameObject);
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game 1") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
        {
            Destroy(this.gameObject);
        }
    }
}
