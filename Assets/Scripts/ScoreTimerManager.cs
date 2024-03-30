using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreTimerManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public float timerValue;
    public bool timerRunning;

    private void Start()
    {
        timerValue = StatsManager.Instance.globalTimer;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (timerRunning)
        {
            timerValue -= Time.deltaTime;
            if (timerValue <= 0)
            {
                timerValue = 0;
                timerRunning = false;
                Debug.Log("Time's up!");
            }
            UpdateTimerDisplay();
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timerValue / 60);
        int seconds = Mathf.FloorToInt(timerValue % 60);
        int tenths = Mathf.FloorToInt((timerValue * 10) % 10);

        string timerString = string.Format("{0:00}:{1:00}.{2}", minutes, seconds, tenths);
        timerText.text = timerString;
    }
}
