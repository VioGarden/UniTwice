using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizHideShowPlease : MonoBehaviour
{
    public GameObject qBox;

    public void Start()
    {
        qBox.SetActive(false);
    }

    public void show()
    {
        qBox.SetActive(true);
    }

    public void hide()
    {
        qBox.SetActive(false);
    }
}
