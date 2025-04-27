using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScoreManager : MonoBehaviour
{

    private int currentScore = 0;

    private static GameScoreManager _instance;
    public static GameScoreManager Instance
        { get { return _instance; } }

    private void Awake()
    {

        if (_instance == null)
        {
            _instance = this;
        }

        //ensures that there is only one singleton
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }


        DontDestroyOnLoad(this.gameObject);
    }

    public int GetStoneScore()
    {
        return currentScore; // sends the current score
    }

    public void AddtoScore(int addedScore)
    { 
        currentScore += addedScore;
        return;
    } // add a customisable amount to the score

    public int ThrewStone()
    { 
        currentScore --;
        return currentScore;
    } //remove 1 from the score if the player threw one of their stones and return the current score to make sure the player doesnt somehow throw more stones than htey have
}
