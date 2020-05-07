using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHit : MonoBehaviour
{
    public Enemy EnemyScript;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 2f);

        if (hit)
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                EnemyScript.GetComponent<Enemy>(). Hit(1);
                //Debug.Log("RayHit");
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.up * 2f, Color.green);
        }
    }
}
