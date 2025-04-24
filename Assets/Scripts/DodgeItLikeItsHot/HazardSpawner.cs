using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    public GameObject rockPrefab;

    public Vector3 spawnAreaSize = new Vector3(10f, 0.5f, 10f);

    public void SpawnRocks()
    {
        GameObject rockPrefabClone = Instantiate(rockPrefab) as GameObject;
        rockPrefabClone.transform.position = new Vector3(Random.Range(-1.1f, 1.1f), 3, -8.648f);
    }
}
