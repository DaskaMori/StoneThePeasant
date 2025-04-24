using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float totalTime = 20f; // Initial time in seconds
    public TextMeshProUGUI timerText; // Assign the UI Text element in the Inspector

    void Start()
    {
        // Optionally, initialize the timer text here.
        // timerText.text = totalTime.ToString("0");
    }

    void Update()
    {
        if (totalTime > 0)
        {
            totalTime -= Time.deltaTime;
            // Update the UI Text with the remaining time
            timerText.text = Mathf.Ceil(totalTime).ToString(); // Display as whole number
        }
    }
}
