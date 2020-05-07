using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public GameObject ShieldImage;
    public bool Shielded;

    float Cooldown;
    public float CooldownTotal;

    public int Count;
    public float Active;
    //public TextMeshProUGUI CooldownText;
    public GameObject ShieldSprite;
    public Image CooldownDisplay;
    Image display;


    // Start is called before the first frame update
    void Start()
    {
        Shielded = false;
        display = CooldownDisplay.GetComponent<Image>();
        Count = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //CooldownText.text = "Shield Cooldown: " + Cooldown;
        //PlayerPrefs.SetInt("Shielded", Shielded);

        //shield cooling down
        if (Count == 0)
        {
            ShieldSprite.transform.gameObject.SetActive(false);
            Cooldown = Cooldown - Time.deltaTime;
            display.fillAmount = (CooldownTotal - Cooldown)/ CooldownTotal;
        }

        //Ready to shield
        if (Count == 1)
        {
            if (Input.GetKey(KeyCode.RightShift))
            {
                Shielded = true;
                Cooldown = CooldownTotal;
                Count = 2;
                Active = 5;
            }
        }
        //Shield Active
        if (Count == 2)
        {
            ShieldSprite.transform.gameObject.SetActive(true);
            Active = Active - Time.deltaTime;
            display.color = Color.red;
            if (Active <= 0)
            {
                Shielded = false;
                Count = 0;
                display.color = Color.white;
            }
        }
        //is cooled down
        if (Cooldown <= 0 && Count == 0)
        {
            Count++;
        }
    }
}
