using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    //public int Sheilded = 0;
    //public Transform Enemy;
    public float moveSpeed = 7.5f;
    //public float Speed;
    public TextMeshProUGUI PlayerHealth;
    public static int Health;
    public int totalHealth;
    Animator anim;
    Rigidbody2D rb;
    public GameObject playershield;
    public GameObject shieldprop;
    float xSpeed;
    float ySpeed;


    string[] animBoolName;
    bool[] animBool;

    float counter;

    //private var childObj : Transform;

    // Start is called before the first frame update
    void Start()
    {
       // childObj = transform.Find("Shield");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        animBoolName = new string []{ "xN", "xP", "yN", "yP"};
        animBool = new bool[4];
        ResetHealth();
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(counter>0)
        {
            counter -= Time.deltaTime;
        }
        xSpeed = 0f;
        ySpeed = 0f;

        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)))//&& transform.position.x < 6.37f
        {
            xSpeed = moveSpeed;
        }

        else if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)))//& transform.position.x > -6.37f
        {
            xSpeed = -moveSpeed;
        }

        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)))//&& transform.position.y< 1.69f
        {
            ySpeed = moveSpeed;
        }

        else if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))//&& transform.position.y > -3.38f
        {
            ySpeed = -moveSpeed;
        }
        UpdateAnim();

        rb.velocity = new Vector2(xSpeed, ySpeed);




        //var degrees = Speed * Time.deltaTime;

        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Enemy.rotation, degrees);
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            PlayerHealth.text = "Player Health: " + Health;
        }
    }

    public void UpdateAnim()
    {
        if(xSpeed!=0)
        {
            if (xSpeed < 0)
            {
                animBool[0] = true;
                animBool[1] = false;
            }
            else
            {
                animBool[1] = true;
                animBool[0] = false;
            }
        }
        else
        {
            animBool[0] = false;
            animBool[1] = false;
        }
        if (ySpeed != 0 && xSpeed==0)
        {
            if (ySpeed < 0)
            {
                animBool[2] = true;
                animBool[3] = false;
            }
            else
            {
                animBool[3] = true;
                animBool[2] = false;
            }
        }
        else
        {
            animBool[2] = false;
            animBool[3] = false;
        }

        for(int i=0; i<animBoolName.Length; i++)
        {
            anim.SetBool(animBoolName[i], animBool[i]);
        }


    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject a = col.gameObject;
        if (a.tag == "Ow" && counter <= 0)
        {
            if(!checkName(a, "idle"))
            {
                if(GetComponent<Shield>() != null)
                {
                    if (!GetComponent<Shield>().Shielded)
                    {
                        Health--;
                        counter = 2f;
                    }
                }


                if (Health <= 0)
                {
                    ResetHealth();
                    PlayerPrefs.SetInt("lastScene", SceneManager.GetActiveScene().buildIndex);
                    SceneManager.LoadScene("Lose screen");
                }
            } 
        }
    }

    bool checkName(GameObject a, string name)
    {
        return (a.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(name));
    }

    public void ResetHealth()
    {
        Health = totalHealth;
    }
}
