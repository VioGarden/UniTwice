using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCurrent : MonoBehaviour
{
    public GameObject[] doors; // Array to store the door GameObjects

    public bool doorStart;

    public string[] doorNames;

    public bool[] states;

    private void Start()
    {
        states = DoorManager.Instance.doorStates;

        doorNames = DoorManager.Instance.doorNames;

        doors = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            doors[i] = transform.GetChild(i).gameObject;
        }

        for (int j = 0; j < doors.Length; j++)
        {
            if(states[j])
            {
                doors[j].SetActive(true);
            }
            else
            {
                doors[j].SetActive(false);
            }
        }

    }
}
