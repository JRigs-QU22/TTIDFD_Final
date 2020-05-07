using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutsceneController : MonoBehaviour
{
    public GameObject player;
    public GameObject hermes;
    public GameObject temple;

    bool writing;
    bool completedFirstLine;

    Vector3 playerPosition;
    public float speed;

    private bool isAnimating;
    public string[] animBoolName;
    public bool[] animBool;
    public int a;
    public Sprite hermiaRight;

    public string[] dialogue;
    public TypeWriterText HermiaWriter;
    public TypeWriterText HermesWriter;
    int line =0;

    public GameObject[] texts;


    bool collidedOnce = true;
    // Start is called before the first frame update
    void Start()
    {
        isAnimating = false;
        a = 1;
        completedFirstLine = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(completedFirstLine)
        {
            if (HermesWriter.Completed())
            {

                player.GetComponent<SpriteRenderer>().sprite = hermiaRight;
                line++;
                completedFirstLine = false;
                animationC();

            }
        }
        if (hermes.activeInHierarchy)
        {
            if (hermes.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("hermes_idle"))
            {
                writing = true;
            }
        }

        if (writing)
        {
            text();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && collidedOnce)
        {

            player.GetComponent<PlayerMove>().enabled = false;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            HermesWriter.setString(dialogue[line]);
            HermesWriter.StartTyping();
            animationB();
        }
    }

    void text()
    {
        if(HermesWriter.Completed() == true && HermiaWriter.Completed() == true)
        {

            player.GetComponent<SpriteRenderer>().sprite = hermiaRight;
            line++;
            if(line < dialogue.Length)
            {
                if (line != 6 && line != 10 && line !=13)
                {
                    WriteText(HermesWriter, dialogue[line]);
                }
                else
                {
                    WriteText(HermiaWriter, dialogue[line]);
                }
            }
            else
            {
                hermes.GetComponent<Animator>().SetTrigger("go");
                player.GetComponent<PlayerMove>().enabled = true;
                player.GetComponent<Animator>().enabled = true;
                Destroy(texts[0]);
                Destroy(texts[1]);
                temple.GetComponent<BoxCollider2D>().enabled = true;
                Destroy(gameObject);
            }

        }
        
        
    }

    //void animationA()
    //{
    //    // step = Time.deltaTime * speed;
    //    playerPosition = player.transform.position;
    //    if (player.transform.position != transform.position)
    //    {
    //        player.transform.position = Vector3.MoveTowards(player.transform.position, transform.position, speed);
    //    }
    //    else
    //    {
    //        isAnimating = false;
    //        animationB();
    //    }
    //    UpdateAnim();

    //}

    void animationB()
    {
        for (int i = 0; i < animBoolName.Length; i++)
        {
            player.GetComponent<Animator>().SetBool(animBoolName[i], false);
        }
        player.GetComponent<Animator>().enabled = false;
        
        completedFirstLine = true;

    }

    void animationC()
    {
        hermes.SetActive(true);
    }

    private void WriteText(TypeWriterText writer, string a)
    {
        writer.setString(a);
        writer.StartTyping();
    }

    //public void UpdateAnim()
    //{
    //    if (playerPosition.x != transform.position.x)
    //    {
    //        if (playerPosition.x > transform.position.x)
    //        {
    //            animBool[1] = true;
    //            animBool[0] = false;
    //        }
    //        else
    //        {
    //            animBool[0] = true;
    //            animBool[1] = false;
    //        }
    //    }
    //    else
    //    {
    //        animBool[0] = false;
    //        animBool[1] = false;
    //    }

    //    if (playerPosition.y != transform.position.y && playerPosition.x == transform.position.x)
    //    {
    //        if (playerPosition.y > transform.position.y)
    //        {
    //            animBool[2] = true;
    //            animBool[3] = false;
    //        }
    //        else
    //        {
    //            animBool[3] = true;
    //            animBool[2] = false;
    //        }
    //    }
    //    else
    //    {
    //        animBool[2] = false;
    //        animBool[3] = false;
    //    }

    //    for (int i = 0; i < animBoolName.Length; i++)
    //    {
    //        player.GetComponent<Animator>().SetBool(animBoolName[i], animBool[i]);
    //    }


    //}
}
