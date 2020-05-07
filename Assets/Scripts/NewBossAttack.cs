using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBossAttack : SpawnFireRing
{
    GameObject weapon;
    //public GameObject fireRing;

    Animator bossAnim;
    Animator weaponAnim;

    public AudioSource smash;
    public GameObject[] firePits;

    float nextAttackTimer;
    int maxHealth;
    int currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        weapon = transform.GetChild(0).GetChild(0).gameObject;
        bossAnim = GetComponent<Animator>();
        weaponAnim = weapon.GetComponent<Animator>();
        maxHealth = GetComponent<Enemy>().Health;
        resetAttackTimer();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = GetComponent<Enemy>().Health;
        if ((checkState(bossAnim, "Walk")||checkState(bossAnim, "idle")) && checkState(weaponAnim, "idle"))
        {
            Debug.Log(nextAttackTimer);
            nextAttackTimer -= Time.deltaTime;
            if (nextAttackTimer <= 0f)
            {
                if (currentHealth > (maxHealth / 3) * 2)
                {
                    attack(3);
                }
                else if (currentHealth > maxHealth / 3)
                {
                    attack(6);
                    Debug.Log(2);
                }
                else
                {
                    attack(9);
                    Debug.Log(3);
                }
            }
        }

        //if(Input.GetKey(KeyCode.K))
        //{
        //    weaponAnim.SetTrigger("jab");
        //}

    }

    void attack(int a)
    {
        a = Random.Range(0, a);

        if(a<3)
        {

            GetComponent<EnemyMove>().setPauseMovement();
            bossAnim.SetTrigger("slam");
        }
        else if(a<6)
        {
            weaponAnim.SetTrigger("jab");
            weapon.GetComponent<BossAttack>().isAiming();
        }
        else
        {
            weaponAnim.SetTrigger("swing");
        }

        smash.PlayDelayed(0.43f);
        resetAttackTimer();
    }

    public void SpawnRing()
    {
        base.SpawnRing(gameObject, "big");

        for(int i = 0; i < firePits.Length; i++)
        {
            base.SpawnRing(firePits[i], "small");
        }
    }

    public void turnOffWeapon()
    {
        weapon.SetActive(!weapon.activeInHierarchy);
    }

    bool checkState(Animator anim, string a)
    {
        return (anim.GetCurrentAnimatorStateInfo(0).IsName(a));
    }

    void resetAttackTimer()
    {
            nextAttackTimer = Random.Range(4, 6);
    }
}
