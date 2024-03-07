using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndOneNPC : MonoBehaviour
{
    public GameObject QuestionBox;
    public GameObject AfterMathNPC;
    public bool conditionMet = false;
    public bool currentState;

    void Start()
    {
        QuestionBox.SetActive(true);
        AfterMathNPC.SetActive(false);
    }

    void Update()
    {
        if (!conditionMet)
        {
            currentState = QuizManager.Instance.canSwitchToNormalNPCNow;
            if (currentState)
            {
                CorrectAnswerNowShow();
            }
        }
    }

    public void CorrectAnswerNowShow()
    {
        QuestionBox.SetActive(false);
        AfterMathNPC.SetActive(true);
    }
}
