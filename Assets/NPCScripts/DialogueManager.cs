using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    // There is 1 Dialogue Manager, and many Dialogue triggers
    public static DialogueManager Instance;

    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;

    // dialogue line read line by line using Queue
    private Queue<DialogueLine> lines;

    public bool isDialogueActive = false;

    public float typingSpeed = 0.05f;

    // to reference dialogue show/hide control
    public DialogueHideShowPlease dhsp2;

    public PlayerStats stats;

    public bool isAndOneDialogueVersion = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        lines = new Queue<DialogueLine>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isAndOneDialogueVersion = dialogue.isAndOne;

        if (isAndOneDialogueVersion)
        {
            ChooseBuffAndOne();
        } else
        {
            ChooseBuff(); // player stat boost upon dialoguez
        }

        isDialogueActive = true;

        lines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
    }

    public void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = lines.Dequeue();

        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;

        StopAllCoroutines();

        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void ChooseBuff()
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
        int randomAD = Random.Range(3, 10);
        stats.IncreaseAD(randomAD);
    }

    private void IncreaseHealthRandom()
    {
        int randomHealth = Random.Range(6, 200);
        stats.Heal(randomHealth);
    }

    private void IncreaseSpeedRandom()
    {
        int randomSpeed = Random.Range(40, 30);
        stats.IncreaseSpeed(randomSpeed);
    }

    private void IncreaseKnockBackRandom()
    {
        float randomKO = Random.Range(0.25f, 20.5f);
        stats.IncreaseKnockBack(randomKO);
    }

    private void IncreaseCamoRandom()
    {
        float randomCamo = Random.Range(0.25f, 50.0f);
        stats.IncreaseCamo(randomCamo);
    }


    private void ChooseBuffAndOne()
    {
        int randomNumber = Random.Range(1, 6);

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
        int randomAD = Random.Range(1, 1);
        stats.IncreaseAD(randomAD);
    }

    private void IncreaseHealthRandomAndOne()
    {
        int randomHealth = Random.Range(1, 1);
        stats.Heal(randomHealth);
    }

    private void IncreaseSpeedRandomAndOne()
    {
        int randomSpeed = Random.Range(1, 1);
        stats.IncreaseSpeed(randomSpeed);
    }

    private void IncreaseKnockBackRandomAndOne()
    {
        float randomKO = Random.Range(1f, 1f);
        stats.IncreaseKnockBack(randomKO);
    }

    private void IncreaseCamoRandomAndOne()
    {
        float randomCamo = Random.Range(1f, 1f);
        stats.IncreaseCamo(randomCamo);
    }



    public void EndDialogue()
    {
        isDialogueActive = false;
        dhsp2.hide();
        //animator.Play("hide");
    }
}