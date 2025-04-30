using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeasantHitDetection : MonoBehaviour
{
    
    [SerializeField] PeasantManager peasantManager;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Stone"))
        {
            peasantManager.peasantHealth--;
        }
    }
}
