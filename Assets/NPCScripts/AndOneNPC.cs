//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[System.Serializable]
//public class AndOneNPCState
//{
//    public bool conditionMet = false;
//    public bool currentState;
//}

//public class AndOneNPC : MonoBehaviour
//{

//    public GameObject QuestionBox;
//    public GameObject AfterMathNPC;

//    public AndOneNPCState AONPCstate;

//    //public bool conditionMet = false;
//    //public bool currentState;

//    void Start()
//    {
//        QuestionBox.SetActive(true);
//        AfterMathNPC.SetActive(false);
//    }

//    void Update()
//    {
//        if (!AONPCstate.conditionMet)
//        {
//            AONPCstate.currentState = QuizManager.Instance.canSwitchToNormalNPCNow;
//            if (AONPCstate.currentState)
//            {
//                CorrectAnswerNowShow();
//            }
//        }
//    }

//    public void CorrectAnswerNowShow()
//    {
//        QuestionBox.SetActive(false);
//        AfterMathNPC.SetActive(true);
//    }
//}
