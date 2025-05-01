using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAndAttack : MonoBehaviour
{
    [SerializeField] private GameObject stonelessPopup;
    [SerializeField] private GameObject stonePrefab;
    private int currentScore;
    private bool canAttack = true;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            currentScore = GameScoreManager.Instance.GetStoneScore();
            if (currentScore > 0 && canAttack)
            {
             //   StartCoroutine(ThrowCooldown());
                GameScoreManager.Instance.ThrewStone();
                Instantiate(stonePrefab, transform.position, Quaternion.identity);
            }
            else
            {
                StartCoroutine(Stoneless());
            }
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
    }

    IEnumerator ThrowCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(1f);
        canAttack = true;
    }

    IEnumerator Stoneless()
    {
        stonelessPopup.SetActive(true);
        yield return new WaitForSeconds(1f);
        stonelessPopup.SetActive(false);
    }
    
}
