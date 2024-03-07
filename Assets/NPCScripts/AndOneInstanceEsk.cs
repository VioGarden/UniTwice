using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndOneInstanceEsk : MonoBehaviour
{

    public GameObject[] questionBoxes;
    public GameObject[] characterBoxes;

    public GameObject currentQuestionBox;

    void Start()
    {
        questionBoxes = new GameObject[transform.childCount];
        characterBoxes = new GameObject[transform.childCount];

        // Loop through each nested GameObject
        for (int i = 0; i < transform.childCount; i++)
        {
            // Check if the nested GameObject has at least two children
            if (transform.GetChild(i).childCount >= 2)
            {
                // Assign the first child to questionBoxes
                questionBoxes[i] = transform.GetChild(i).GetChild(0).gameObject;
                questionBoxes[i].SetActive(true);

                // Assign the second child to characterBoxes
                characterBoxes[i] = transform.GetChild(i).GetChild(1).gameObject;
                characterBoxes[i].SetActive(false);
            }
            else
            {
                Debug.LogWarning("Nested GameObject at index " + i + " does not have enough children.");
            }
        }

    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    public void QuizSolved(string quizboxname)
    {
        for (int i = 0; i < questionBoxes.Length; i++)
        {
            if (questionBoxes[i].name == quizboxname)
            {
                // Deactivate the current question box and activate the character box
                questionBoxes[i].SetActive(false);
                characterBoxes[i].SetActive(true);
                return; // Exit the loop once the match is found
            }
        }
    }
}
