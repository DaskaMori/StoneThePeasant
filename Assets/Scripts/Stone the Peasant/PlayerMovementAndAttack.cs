using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAndAttack : MonoBehaviour
{

    [SerializeField] private GameObject stonePrefab;

    // Update is called once per frame
    void Update()
    {
/*
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(stonePrefab, transform.position, Quaternion.identity);
        }

        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime * 5);
        }

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(Vector3.left * Time.deltaTime * 5);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(Vector3.back * Time.deltaTime * 5);
        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Vector3.right * Time.deltaTime * 5);
        }
*/

        Rigidbody rb = GetComponent<Rigidbody>();

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * 10f, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(transform.right * -10f, ForceMode.Impulse);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(Vector3.back * Time.deltaTime * 5);
        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Vector3.right * Time.deltaTime * 5);
        }


        
    }
}
