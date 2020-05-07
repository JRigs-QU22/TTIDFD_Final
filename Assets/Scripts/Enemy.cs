using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    public GameObject Mino;
    public TextMeshProUGUI EnemyHealth;
    public Image healthBar;
    public int Health;
    float totalHealth;
    Color32 Red = new Color32(255, 0, 0, 255);
    Color32 Normal = new Color32(255, 255, 255, 255);
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        totalHealth = Health;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyHealth.text = "Boss Health: " + Health;

        //Vector2 move = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        Mino.GetComponent<SpriteRenderer>().color = Normal;
    }


    public virtual void Hit(int Damage)
    {
        //Color WasHit = new Color(0, 0, 255);
        //this.transform.gameObject.SetActive(false);
        if(GetComponent<EnemyMove>().pauseMovement)
        {
            Health = Health - Damage;

            healthBar.fillAmount = (float)Health / totalHealth;
            //Mino.GetComponent<SpriteRenderer>().color = Red;
            
            
            /*
            if (Health > 0)
            {
                Mino.GetComponent<SpriteRenderer>().color = Normal;
            }
            */
            if (Health <= 0)
            {
                SceneManager.LoadScene("cutscene3");
                //Destroy(this.gameObject);
                //Destroy(EnemyHealth);
            }
            //Debug.Log("Hit");
        }
    
        

    }
}
