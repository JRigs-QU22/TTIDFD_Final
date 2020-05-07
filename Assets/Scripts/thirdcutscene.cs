using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdcutscene : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Animator minoAnim;
    public GameObject reward;
    public GameObject player;

    public GameObject textA;
    public GameObject textB;

    private bool once;

    // Start is called before the first frame update
    void Start()
    {
        once = true;   
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueManager.Completed() && once)
        {
            minoAnim.SetTrigger("go");
            reward.SetActive(true);
            player.GetComponent<PlayerMove>().enabled = true;
            player.GetComponent<Animator>().enabled = true;

            textA.SetActive(false);
            textB.SetActive(false);

            once = false;
        }
    }

}
