using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    // Stats displayed on Player HUD
    [SerializeField] private TextMeshProUGUI currentCamoTimeText;
    [SerializeField] private TextMeshProUGUI currentHealthText;
    [SerializeField] private TextMeshProUGUI currentSPDText;
    [SerializeField] private TextMeshProUGUI currentADText;
    [SerializeField] private TextMeshProUGUI currentKBText;

    // Updates while in Anya
    public void UpdateHealth(float currentCamoTime, int currentHealth, int currentSPD, int currentAD, float currentKB)
    {
        currentCamoTimeText.text = currentCamoTime.ToString("F2");
        currentHealthText.text = currentHealth.ToString();
        currentSPDText.text = currentSPD.ToString();
        currentADText.text = currentAD.ToString();
        currentKBText.text = currentKB.ToString("F1");
    }

    // Updates while in Camo
    public void UpdateCamoTime(float currentCamoTime)
    {
        currentCamoTimeText.text = currentCamoTime.ToString("F2");
    }
}
