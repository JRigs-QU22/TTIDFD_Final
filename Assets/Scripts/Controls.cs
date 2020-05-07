using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    public KeyCode Attack = KeyCode.A;
    public KeyCode Get;
    public KeyCode Shield { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Attack))
        {

            Debug.Log("Attack");
        }
    }
    
    public void OnGUI()
    {
        //if (Event.current.Equals(Event.KeyboardEvent()))
        //{
        //    Debug.Log("atack");
        //}
         if (Event.current.type == EventType.KeyDown)
        {
            Debug.Log("press");
            
        }


    }
}
