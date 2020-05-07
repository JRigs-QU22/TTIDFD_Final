using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FourthCutscene : MonoBehaviour
{
    public GameObject blackCanvas;
    public Image[] bAndWSprite;
    public DialogueManager dialogueManagerA;
    public DialogueManager dialogueManagerB;

    public GameObject button;

    float percentage;
    float totalFadeTime;
    float ellapsedFadeTime;
    // Start is called before the first frame update
    void Start()
    {
        ellapsedFadeTime = 0;
        percentage = 0;
        totalFadeTime = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueManagerA.Completed())
        {
            if (percentage < 1)
            {
                PercentageUpdate(1);

                blackCanvas.GetComponent<Image>().color = new Color(0f, 0f, 0f, percentage);
            }
            else if (percentage >= 1 && percentage < 2)
            {
                PercentageUpdate(2);
                for(int i = 0; i<bAndWSprite.Length; i++)
                {
                    bAndWSprite[i].color = new Color(1, 1, 1, (percentage - 1));
                }
            }
            else if (percentage >= 2 && percentage < 3)
            {
                dialogueManagerB.enabled = true;
                if (dialogueManagerB.Completed())
                {
                    percentage = 3;
                }
            }
            else if (percentage >= 3)
            {
                button.SetActive(true);
            }
        }        

    }

    void PercentageUpdate(float upperLimit)
    {
        ellapsedFadeTime += Time.deltaTime;
        percentage = ellapsedFadeTime;

        if (percentage > upperLimit)
        {
            percentage = upperLimit;
        }
    }

}
