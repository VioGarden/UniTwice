using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    // global variable of player stats.
    // Needed because player stats gets destoryed when entering a new scene.
    public static StatsManager Instance;

    public float globalCamoTime;
    public int globalHealth;
    public int globalSpeed;
    public int globalAttackDamage;
    public float globalKnockBack;
    public bool globalIsDead;

    // variable to update global stats upon game launch
    public bool gameHasStarted = false;

    // variables to keep track of score and timer
    public float globalScore;
    public float globalMultiplier;
    public float globalTimer;

    private void Awake()
    {
        if (Instance != null)
        {
            //Destroy(gameObject); // dont need this line for now
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
