using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public PlayerStats stats;

    public static QuizManager Instance;

    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI quizArea;

    public TextMeshProUGUI OptA;
    public TextMeshProUGUI OptB;
    public TextMeshProUGUI OptC;
    public TextMeshProUGUI OptD;

    // This option is never displayed, but just used in script to check answer
    public TextMeshProUGUI CorrectOpt;

    private Queue<QuizLine> lines;

    public bool isQuizActive = false;

    public float typingSpeed = 0.02f;

    public QuizHideShowPlease qhsp2;

    public Quiz quizVariables;

    public bool isAndOneQuizVersion = false; // Choosing if quiz is one that repeats or quiz loot box

    public bool AndOneBool = false; // If loot box quiz, want to send msg later on

    public bool canSwitchToNormalNPCNow = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        lines = new Queue<QuizLine>();
    }

    public void StartQuiz(Quiz quiz)
    {
        isQuizActive = true;

        isAndOneQuizVersion = quiz.isAndOne; // check is coupled npc

        OptA.text = quiz.options.optionA;

        OptB.text = quiz.options.optionB;

        OptC.text = quiz.options.optionC;

        OptD.text = quiz.options.optionD;

        CorrectOpt.text = quiz.options.correctOption;


        lines.Clear();

        foreach (QuizLine quizLine in quiz.quizLines)
        {
            lines.Enqueue(quizLine);
        }

        DisplayNextQuizLine();

    }

    public void DisplayNextQuizLine()
    {
        if (lines.Count == 0)
        {
            EndQuiz();
            return;
        }

        QuizLine currentLine = lines.Dequeue();

        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;

        StopAllCoroutines();

        StartCoroutine(TypeSentence(currentLine));
    }


    public void OptionAChosen()
    {
        if (!isAndOneQuizVersion)
        {
            if (OptA.text == CorrectOpt.text)
            {
                ChooseBuff();
            }
            else
            {
                ChooseDeBuff();
            }
            EndQuiz();
        }
        else
        {
            if (OptA.text == CorrectOpt.text)
            {
                ChooseBuffAndOne();
            }
            else
            {
                ChooseDeBuffAndOne();
            }
            EndQuiz();
        }
    }

    public void OptionBChosen()
    {
        if (!isAndOneQuizVersion)
        {
            if (OptB.text == CorrectOpt.text)
            {
                ChooseBuff();
            }
            else
            {
                ChooseDeBuff();
            }
            EndQuiz();
        }
        else
        {
            if (OptB.text == CorrectOpt.text)
            {
                ChooseBuffAndOne();
            }
            else
            {
                ChooseDeBuffAndOne();
            }
            EndQuiz();
        }
    }

    public void OptionCChosen()
    {
        if (!isAndOneQuizVersion)
        {
            if (OptC.text == CorrectOpt.text)
            {
                ChooseBuff();
            }
            else
            {
                ChooseDeBuff();
            }
            EndQuiz();
        }
        else
        {
            if (OptC.text == CorrectOpt.text)
            {
                ChooseBuffAndOne();
            }
            else
            {
                ChooseDeBuffAndOne();
            }
            EndQuiz();
        }
    }

    public void OptionDChosen()
    {
        if (!isAndOneQuizVersion)
        {
            if (OptD.text == CorrectOpt.text)
            {
                ChooseBuff();
            }
            else
            {
                ChooseDeBuff();
            }
            EndQuiz();
        }
        else
        {
            if (OptD.text == CorrectOpt.text)
            {
                ChooseBuffAndOne();
            }
            else
            {
                ChooseDeBuffAndOne();
            }
            EndQuiz();
        }
    }


    public void ChooseBuff()
    {
        int randomNumber = Random.Range(1, 6);

        // Execute the corresponding function based on the selected number
        switch (randomNumber)
        {
            case 1:
                IncreaseADRandom();
                break;
            case 2:
                IncreaseHealthRandom();
                break;
            case 3:
                IncreaseSpeedRandom();
                break;
            case 4:
                IncreaseKnockBackRandom();
                break;
            case 5:
                IncreaseCamoRandom();
                break;
        }

    }

    private void IncreaseADRandom()
    {
        int randomAD = Random.Range(1, 30);
        stats.IncreaseAD(randomAD);
    }

    private void IncreaseHealthRandom()
    {
        int randomHealth = Random.Range(1, 50);
        stats.Heal(randomHealth);
    }

    private void IncreaseSpeedRandom()
    {
        int randomSpeed = Random.Range(1, 60);
        stats.IncreaseSpeed(randomSpeed);
    }

    private void IncreaseKnockBackRandom()
    {
        float randomKO = Random.Range(0.5f, 45.5f);
        stats.IncreaseKnockBack(randomKO);
    }

    private void IncreaseCamoRandom()
    {
        float randomCamo = Random.Range(0.5f, 30.5f);
        stats.IncreaseCamo(randomCamo);
    }





    private void ChooseBuffAndOne()
    {
        int randomNumber = Random.Range(1, 6);

        canSwitchToNormalNPCNow = true;

        // Execute the corresponding function based on the selected number
        switch (randomNumber)
        {
            case 1:
                IncreaseADRandomAndOne();
                break;
            case 2:
                IncreaseHealthRandomAndOne();
                break;
            case 3:
                IncreaseSpeedRandomAndOne();
                break;
            case 4:
                IncreaseKnockBackRandomAndOne();
                break;
            case 5:
                IncreaseCamoRandomAndOne();
                break;
        }

    }

    private void IncreaseADRandomAndOne()
    {
        int randomAD = Random.Range(7, 7);
        stats.IncreaseAD(randomAD);
    }

    private void IncreaseHealthRandomAndOne()
    {
        int randomHealth = Random.Range(7, 7);
        stats.Heal(randomHealth);
    }

    private void IncreaseSpeedRandomAndOne()
    {
        int randomSpeed = Random.Range(7, 7);
        stats.IncreaseSpeed(randomSpeed);
    }

    private void IncreaseKnockBackRandomAndOne()
    {
        float randomKO = Random.Range(7f, 7f);
        stats.IncreaseKnockBack(randomKO);
    }

    private void IncreaseCamoRandomAndOne()
    {
        float randomCamo = Random.Range(7f, 7f);
        stats.IncreaseCamo(randomCamo);
    }





    // we don't want to debuff if a stat is already at its floor
    public List<int> deBuffableStats()
    {
        // list of numbers, add cases where stat can be debuffed
        // later, switch statement will then choose from options
        List<int> numbers = new List<int>();

        if (stats.attackDamage != 1)
        {
            numbers.Add(1);
        }

        // health can always be lowered, when no health, game over
        numbers.Add(2);

        if (stats.speed != 5)
        {
            numbers.Add(3);
        }
        if (stats.knockBack != 1)
        {
            numbers.Add(4);
        }
        if (stats.camoTime != 0)
        {
            numbers.Add(5);
        }

        return numbers;
    }

    public void ChooseDeBuff()
    {
        List<int> debuffableStats = deBuffableStats(); 
        int randomNumber = Random.Range(0, debuffableStats.Count); 
        int selectedDebuff = debuffableStats[randomNumber]; 

        // Execute the corresponding function based on the selected number
        switch (selectedDebuff)
        {
            case 1:
                DecreaseADRandom();
                break;
            case 2:
                DecreaseHealthRandom();
                break;
            case 3:
                DecreaseSpeedRandom();
                break;
            case 4:
                DecreaseKnockBackRandom();
                break;
            case 5:
                DecreaseCamoRandom();
                break;
        }

    }

    private void DecreaseADRandom()
    {
        int randomAD = Random.Range(1, 8);
        stats.DecreaseAD(randomAD);
    }

    private void DecreaseHealthRandom()
    {
        int randomHealth = Random.Range(1, 15);
        stats.Damage(randomHealth);
    }

    private void DecreaseSpeedRandom()
    {
        int randomSpeed = Random.Range(1, 8);
        stats.DecreaseSpeed(randomSpeed);
    }

    private void DecreaseKnockBackRandom()
    {
        float randomKO = Random.Range(0.5f, 4.5f);
        stats.DecreaseKnockBack(randomKO);
    }

    private void DecreaseCamoRandom()
    {
        float randomCamo = Random.Range(0.5f, 7.5f);
        stats.DecreaseCamo(randomCamo);
    }



    public void ChooseDeBuffAndOne()
    {
        List<int> debuffableStats = deBuffableStats();
        int randomNumber = Random.Range(0, debuffableStats.Count);
        int selectedDebuff = debuffableStats[randomNumber];

        // Execute the corresponding function based on the selected number
        switch (selectedDebuff)
        {
            case 1:
                DecreaseADRandomAndOne();
                break;
            case 2:
                DecreaseHealthRandomAndOne();
                break;
            case 3:
                DecreaseSpeedRandomAndOne();
                break;
            case 4:
                DecreaseKnockBackRandomAndOne();
                break;
            case 5:
                DecreaseCamoRandomAndOne();
                break;
        }

    }

    private void DecreaseADRandomAndOne()
    {
        int randomAD = Random.Range(7, 7);
        stats.DecreaseAD(randomAD);
    }

    private void DecreaseHealthRandomAndOne()
    {
        int randomHealth = Random.Range(7, 7);
        stats.Damage(randomHealth);
    }

    private void DecreaseSpeedRandomAndOne()
    {
        int randomSpeed = Random.Range(7, 7);
        stats.DecreaseSpeed(randomSpeed);
    }

    private void DecreaseKnockBackRandomAndOne()
    {
        float randomKO = Random.Range(7f, 7f);
        stats.DecreaseKnockBack(randomKO);
    }

    private void DecreaseCamoRandomAndOne()
    {
        float randomCamo = Random.Range(7f, 7f);
        stats.DecreaseCamo(randomCamo);
    }




    IEnumerator TypeSentence(QuizLine quizLine)
    {
        quizArea.text = "";
        foreach (char letter in quizLine.line.ToCharArray())
        {
            quizArea.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void EndQuiz()
    {
        isQuizActive = false;
        qhsp2.hide();
    }
}