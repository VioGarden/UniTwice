using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHideShowPlease : MonoBehaviour
{
    // only parent class can control children SetActive
    public GameObject dBox; // dialogue box

    public void Start()
    {
        dBox.SetActive(false);
    }

    public void show() // when need dialogue box to pop up
    {
        dBox.SetActive(true);
    }

    public void hide() // make dialogue box disappear
    {
        dBox.SetActive(false);
    }
}
