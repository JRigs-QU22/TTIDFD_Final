using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public SpawnFireRing spawnFireRing;
    public float counterLimit;
    private float countDown;
    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if(countDown <= 0f)
        {
            spawn();
        }
    }

    void spawn()
    {
        countDown = counterLimit;
        spawnFireRing.SpawnRing(gameObject, "big");
    }
}
