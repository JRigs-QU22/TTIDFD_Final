using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public bool[] hermiaOrNot;
    public string[] dialogue;
    public TypeWriterText[] writers;
    int line;
    private bool completed;
    bool lineCompleted;

    private void Start()
    {
        line = 0;
        lineCompleted = true;
    }
    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<writers.Length; i++)
        {
            lineCompleted = lineCompleted && writers[i].Completed();
        }
        if (lineCompleted)
        {
            if (line < dialogue.Length)
            {
                if (hermiaOrNot[line])
                {
                    WriteText(writers[0], dialogue[line]);
                }
                else
                {
                    WriteText(writers[1], dialogue[line]);
                }
            }
            else
            {
                completed = true;
            }
            line++;
        }
        lineCompleted = true;
    }

    private void WriteText(TypeWriterText writer, string a)
    {
        writer.setString(a);
        writer.StartTyping();
    }

    public bool Completed()
    {
        return completed;
    }
}
