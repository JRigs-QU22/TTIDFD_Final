using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stab : MonoBehaviour
{
    float charging;
    public float chargeTime;
    Animator anim;
    bool hasHit;
    public AudioSource strike;
    public AudioSource swoosh;
    // Start is called before the first frame update
    void Start()
    {
        charging = 0f;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hasHit = false;
        } 
        else if(Input.GetKey(KeyCode.Space))
        {
            charging += Time.deltaTime;
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            if(charging>=chargeTime)
            {
                anim.SetTrigger("Swing");
                swoosh.Play();
                GetComponent<SpriteRenderer>().color = new Color(1, 0.9614235f, 0f, 1);
            }
            else
            {
                anim.SetTrigger("Jab");
                strike.Play();
            }
            
            charging = 0f;
        }

        if(charging >= chargeTime)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }

    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !hasHit)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Swing"))
            {
                collision.gameObject.GetComponent<Enemy>().Hit(2);
                hasHit = true;
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jab") && !hasHit)
            {
                collision.gameObject.GetComponent<Enemy>().Hit(1);
                hasHit = true;
            }
        }
    }

}
