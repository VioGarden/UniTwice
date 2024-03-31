using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class DoorManager : MonoBehaviour
{
    public static DoorManager Instance; // Singleton instance for easy access

    public string[] doorNames; // Array to store the names of doors

    public bool[] doorStates;

    public bool doorStart;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        if (!doorStart)
        {
            doorNames = new string[4];
            doorNames[0] = "DoorRoom2Twice";
            doorNames[1] = "DoorRoom2Basketball";
            doorNames[2] = "DoorRoom2BreakingBad";
            doorNames[3] = "DoorRoom2BattleB";

            doorStates = new bool[4];
            doorStates[0] = true;
            doorStates[1] = true;
            doorStates[2] = true;
            doorStates[3] = true;

            doorStart = true;
        }
    }

    private void Start()
    {
        if (!doorStart)
        {
            doorNames = new string[4];
            doorNames[0] = "DoorRoom2Twice";
            doorNames[1] = "DoorRoom2Basketball";
            doorNames[2] = "DoorRoom2BreakingBad";
            doorNames[3] = "DoorRoom2BattleB";

            doorStates = new bool[4];
            doorStates[0] = true;
            doorStates[1] = true;
            doorStates[2] = true;
            doorStates[3] = true;

            doorStart = true;
        }
    }

    public void SetDoor(string doorName)
    {
        int index = -1; // Initialize index to -1 (not found)

        for (int i = 0; i < doorNames.Length; i++)
        {
            if (doorNames[i] == doorName)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            Debug.Log("DoorNotFound : " + doorName);
        }
        else
        {
            doorStates[index] = false;
        }
    }
}
