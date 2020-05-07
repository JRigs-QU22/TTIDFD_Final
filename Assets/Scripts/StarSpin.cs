using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpin : MonoBehaviour
{
    public Vector3 Spin;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Spin * Time.deltaTime);

    }

    public void SpinX(float x)
    {
        Spin.x = x;
    }

    public void SpinY(float y)
    {
        Spin.y = y;
    }

    public void SpinZ(float z)
    {
        Spin.z = z;
    }
}
