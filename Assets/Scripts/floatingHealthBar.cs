using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class floatingHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Color bigHealthColor = Color.green;
    [SerializeField] private Color mediumHealthColor = Color.yellow;
    [SerializeField] private Color lowHealthColor = Color.red;
    [SerializeField] private float mediumHealthThreshold = 0.5f;
    [SerializeField] private float lowHealthThreshold = 0.2f;

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;

        // Change color based on health value
        if (slider.value <= lowHealthThreshold)
        {
            slider.fillRect.GetComponent<Image>().color = lowHealthColor;
        }
        else if (slider.value <= mediumHealthThreshold)
        {
            slider.fillRect.GetComponent<Image>().color = mediumHealthColor;
        }
        else
        {
            slider.fillRect.GetComponent<Image>().color = bigHealthColor;
        }
    }

    //[SerializeField] private Slider slider;

    //public void UpdateHealthBar(float currentValue, float maxValue)
    //{
    //    slider.value = currentValue / maxValue;
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
