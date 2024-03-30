using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MultiplierManager : MonoBehaviour
{
    public TextMeshProUGUI multText;
    public float multValue;


    private void Start()
    {
        multValue = StatsManager.Instance.globalMultiplier;
        UpdateMultDisplay();
    }

    void Update()
    {
        if (true)
        {
            multValue = StatsManager.Instance.globalMultiplier;
            UpdateMultDisplay();
        }
    }

    private void UpdateMultDisplay()
    {
        string multString = string.Format("{0:0.00}", multValue) + "x";
        multText.text = multString;
    }
}
