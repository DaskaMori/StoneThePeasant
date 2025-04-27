using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownStoneManager : MonoBehaviour
{
    
    [SerializeField] private GameObject player;
    [SerializeField] private Material stoneMaterialOne;
    [SerializeField] private Material stoneMaterialTwo;
    [SerializeField] private Material stoneMaterialThree;
    private int chosenTexture;
    
    // Start is called before the first frame update
    void Start()
    {
        chosenTexture = Random.Range(0, 2);
        if (chosenTexture == 0)
        {
            gameObject.GetComponent<Renderer>().material = stoneMaterialOne;
        }

        if (chosenTexture == 1)
        {
            gameObject.GetComponent<Renderer>().material = stoneMaterialTwo;
        }

        if (chosenTexture == 2)
        {
            gameObject.GetComponent<Renderer>().material = stoneMaterialThree;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
        Vector3 eulerAngles = transform.eulerAngles;
        transform.eulerAngles = eulerAngles;
    }
}
