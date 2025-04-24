using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    
    public int stoneScore = 0;
    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    
}
