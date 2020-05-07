using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnObject : MonoBehaviour
{
    public GameObject a;
    public bool alsoChangeSound;
    public AudioSource audioSource;
    public AudioClip newSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            a.SetActive(true);

            if (alsoChangeSound)
            {
                audioSource.clip = newSound;
                audioSource.Play();
            }
            Destroy(gameObject);
        }
        
    }
}
