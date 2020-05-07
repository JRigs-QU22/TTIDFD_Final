using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Tutorials used to make this code
//https://www.youtube.com/watch?v=1qbjmb_1hV4
//https://www.youtube.com/watch?v=HqaCQXI54KA

public class TypeWriterText : MonoBehaviour
{
    private string CurrentText = "";
    public string FullText;
    public float Speed = .1f;
    private bool completed;
    // Start is called before the first frame update
    void Start()
    {
        StartTyping();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            Speed = .02f;
        }
    }


    IEnumerator MoveText()
    {
        Debug.Log("start");
        for (int i = 0; i < FullText.Length; i++)
        {
            Debug.Log(i);
            CurrentText = FullText.Substring(0,i);
            this.GetComponent<TextMeshProUGUI>().text = CurrentText;
            yield return new WaitForSeconds(Speed);
        }
        completed = true;
        Speed = 0.1f;
        Debug.Log("End");
    }

    public void StartTyping()
    {
        StartCoroutine(MoveText());
        completed = false;
    }

    public bool Completed()
    {
        return completed;
    }

    public void setString(string a)
    {
        FullText = a;
    }
}
