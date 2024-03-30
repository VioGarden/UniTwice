using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public float scoreValue;

    private void Start()
    {
        scoreValue = StatsManager.Instance.globalScore;
        UpdateScoreDisplay();
    }

    void Update()
    {
        if (true)
        {
            scoreValue = StatsManager.Instance.globalScore;
            UpdateScoreDisplay();
        }
    }

    private void UpdateScoreDisplay()
    {
        string scoreString = string.Format("{0:0.00}", scoreValue);
        scoreText.text = scoreString;
    }
}
