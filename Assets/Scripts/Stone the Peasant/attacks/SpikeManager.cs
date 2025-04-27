using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeManagert : MonoBehaviour
{
    
    [SerializeField] private GameObject player;
    
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
        Vector3 eulerAngles = transform.eulerAngles;
        eulerAngles.x = 0; // Lock X rotation
        transform.eulerAngles = eulerAngles;
        
        transform.position = transform.position + transform.up * 0.1f;
    }
}


