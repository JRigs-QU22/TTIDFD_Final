using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator anim;

    public bool pauseMovement;
    Vector2 pause;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        pauseMovement = false;
        pause = new Vector2(0, 0);

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }


    private void FixedUpdate()
    {
        if (!pauseMovement)
        {
            moveCharacter(movement);
            anim.SetBool("moving", true);
        }
        else
        {
            moveCharacter(pause);
        }
    }


    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));

        if(direction.x<0)
        {
            flipSprite(true);
        }
        else if(direction.x>0)
        {
            flipSprite(false);
        }
    }

    public void setPauseMovement()
    {
        pauseMovement = !pauseMovement;
    }

    void flipSprite(bool a)
    {
        GetComponent<SpriteRenderer>().flipX = a;
    }
}
//taken from https://pressstart.vip/tutorials/2019/07/15/98/follow-enemy-ai.html
//I would reccomend having the enemy stop when doin an attack and keeping them signifigantly slower than the player to maintain balance
