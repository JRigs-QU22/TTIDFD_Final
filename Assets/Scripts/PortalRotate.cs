﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalRotate : MonoBehaviour
{
    public float Speed;
    public GameObject Portal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Portal.transform.Rotate(new Vector3(0, 0,Speed * Time.deltaTime));
    }
}
