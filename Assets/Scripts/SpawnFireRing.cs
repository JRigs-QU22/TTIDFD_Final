using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFireRing : MonoBehaviour
{
    public GameObject ring;
    public GameObject a;

    public virtual void SpawnRing(GameObject position, string animTrigger)
    {
        a = Instantiate(ring);
        a.transform.position = position.transform.position;
        a.GetComponent<Animator>().SetTrigger(animTrigger);
    }
}
