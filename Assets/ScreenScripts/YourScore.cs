using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class YourScore : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public float finalScoreValue;

    private void Start()
    {
        finalScoreValue = StatsManager.Instance.globalScore;
        UpdateScoreDisplay();
    }



    private void UpdateScoreDisplay()
    {
        string finalScoreString = "Final Score : " + string.Format("{0:0.00}", finalScoreValue);
        finalScoreText.text = finalScoreString;
    }
}
