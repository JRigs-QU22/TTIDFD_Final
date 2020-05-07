using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRing : MonoBehaviour
{
    //Animator anim;

    //public float random;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    random = Random.Range(3, 6);
    //    anim = GetComponent<Animator>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if(anim.GetCurrentAnimatorStateInfo(0).IsName("Default"))
    //    {
    //        random -= Time.deltaTime;
    //        if(random<= 0)
    //        {
    //            anim.SetTrigger("Grow");
    //            random = Random.Range(3, 6);
    //        }
    //    }
    //}

    public void delete()
    {
        Destroy(gameObject);
    }
}
