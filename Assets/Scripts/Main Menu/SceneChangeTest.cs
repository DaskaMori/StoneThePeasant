using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SceneManager.LoadScene(3);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(5);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameScoreManager.Instance.AddtoScore(99999);
        }
    }
}
