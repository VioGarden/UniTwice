using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuizCharacter
{
    public string name;
    public Sprite icon;
}

[System.Serializable]
public class QuizLine
{
    public QuizCharacter character;
    [TextArea(3, 10)]
    public string line;
    public QuizOptions options;
}

[System.Serializable]
public class Quiz
{
    public List<QuizLine> quizLines = new List<QuizLine>();
    public QuizOptions options;
    public bool isAndOne;
}

[System.Serializable]
public class QuizOptions
{
    public string optionA;

    public string optionB;

    public string optionC;

    public string optionD;

    public string correctOption;
}

public class QuizTrigger : MonoBehaviour
{
    public Quiz quiz;

    public QuizHideShowPlease qhsp;

    public void TriggerQuiz()
    {
        QuizManager.Instance.StartQuiz(quiz);
    }

    public void ExitQuiz()
    {
        QuizManager.Instance.EndQuiz();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            qhsp.show();
            TriggerQuiz();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            ExitQuiz();
            qhsp.hide();
        }
    }
}