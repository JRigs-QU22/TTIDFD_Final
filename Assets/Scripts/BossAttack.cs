using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    bool aimAtPlayer;
    public GameObject player;
    //public GameObject fireRing;
    GameObject empty;
    GameObject boss;

    private Vector3 target;

    int currentBossHealth;
    int maxBossHealth;

    Rigidbody2D rb;
    Animator anim;
    public AudioSource smash;
    float nextAttackTimer;


    // Start is called before the first frame update
    void Start()
    {
        empty = transform.parent.gameObject;
        rb = empty.GetComponent<Rigidbody2D>();

        boss = empty.transform.parent.gameObject;

        aimAtPlayer = false;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentBossHealth = boss.GetComponent<Enemy>().Health;
        holdPosition();

        if(aimAtPlayer)
        {
            AimWeapon();
        }

    }


    void AimWeapon()
    {
        //this code is taken from https://pressstart.vip/tutorials/2019/07/15/98/follow-enemy-ai.html
        ////it's used to aim the boss's weapon at the enemy during certain attacks
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

    }


    public void isAiming()
    {
       aimAtPlayer = !aimAtPlayer;
        rb.rotation = 0f;

    }

    public void stopBossMovement()
    {
        boss.GetComponent<EnemyMove>().setPauseMovement();
        GetComponent<BoxCollider2D>().enabled = !GetComponent<BoxCollider2D>().enabled;
    }

    void holdPosition()
    {
        empty.transform.position = new Vector3(boss.transform.position.x-0.58f, boss.transform.position.y + 1.68f, 0f);
        //empty.transform.position = boss.transform.position;
    }

    int counter = 0;
    void chainAnim()
    {
        if(counter<2)
        {
            counter++;
            anim.SetTrigger("jab");
            smash.PlayDelayed(0.43f);
        }
        else
        {
            counter = 0;
            isAiming();
        }
    }
}
