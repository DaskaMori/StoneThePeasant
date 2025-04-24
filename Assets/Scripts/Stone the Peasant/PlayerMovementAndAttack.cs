using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAndAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // throw stone
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * 500);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<Rigidbody>().AddForce(transform.right * -500);
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * -500);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Rigidbody>().AddForce(transform.right * 500);
        }
        
    }
}
