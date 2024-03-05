using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
}

// each dialogue character has, name, icon, lines, and a continue button
[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public DialogueHideShowPlease dhsp;

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }

    public void ExitDialogue()
    {
        DialogueManager.Instance.EndDialogue();
    }

    // dialogue appears if player collides with npc
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            dhsp.show();
            TriggerDialogue();
        }
    }

    // dialogue disappears when player no longer collides with npc
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            ExitDialogue();
            dhsp.hide();
        }
    }
}