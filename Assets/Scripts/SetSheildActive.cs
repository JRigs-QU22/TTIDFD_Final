using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetSheildActive : MonoBehaviour
{
    private GameObject a;
    public GameObject shieldTimer;
    public TextMeshProUGUI Type;

    private void Start()
    {
        shieldTimer.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        a = col.gameObject;
        if (a.CompareTag("Player"))
        {
            a.GetComponent<Shield>().enabled = true;
            shieldTimer.SetActive(true);
            Destroy(gameObject);
            Type.transform.gameObject.SetActive(true);
        }
    }
}
