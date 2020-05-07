using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOnCollision : MonoBehaviour
{
    public string collisionTag;
    public Sprite change;
    private static bool changed = false;
    public GameObject col;

    private void Update()
    {
        if(changed)
        {
            col.GetComponent<SpriteRenderer>().sprite = change;
            col.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!changed && col.CompareTag(collisionTag))
        {
            changed = true;
        }
    }
}
