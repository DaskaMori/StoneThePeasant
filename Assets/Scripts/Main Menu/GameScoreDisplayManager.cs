using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScoreDisplayManager : MonoBehaviour
{

    public TextMeshProUGUI stoneCountDisplay;

    private int stoneScoreTemp;
    private string stoneScoreStringTemp;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        stoneScoreTemp = GameScoreManager.Instance.GetStoneScore();
        stoneScoreStringTemp = stoneScoreTemp.ToString();
        stoneCountDisplay.text = stoneScoreStringTemp;
    }
}
