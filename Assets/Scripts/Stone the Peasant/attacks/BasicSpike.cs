using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BasicSpike : MonoBehaviour
{
    [SerializeField] private GameObject playerCharacter;
    [SerializeField] private GameObject spikePrefab;
    
    void Start()
    {
        Transform spikeTarget = playerCharacter.GetComponent<Transform>();
        Vector3 spikeSpawn = spikeTarget.position + Vector3.down * 1f;
        Instantiate(spikePrefab, spikeSpawn, Quaternion.identity);
    }
}
