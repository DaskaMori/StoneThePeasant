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
    private Vector3 moveDirection;
    [SerializeField] private float speed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        
        transform.SetParent(null);
        if (Camera.main != null) moveDirection = Camera.main.transform.forward;

        player = GameObject.FindGameObjectWithTag("Player");
        
        StartCoroutine(MoveContinuously());
        StartCoroutine(StoneDespawn());
    }




    IEnumerator StoneDespawn()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
    
    IEnumerator MoveContinuously()
    {
        while(true)
        {
            // Move the object in the stored direction
            transform.position += moveDirection * (speed * Time.deltaTime);
            yield return null; // Wait for next frame
        }
    }
}
