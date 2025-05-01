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
            Debug.Log("stone: " + collision.gameObject);
            peasantManager.peasantHealth--;
            Destroy(collision.gameObject);
        }
    }
}
