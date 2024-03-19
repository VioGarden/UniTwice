using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()
    {
        
        StatsManager.Instance.globalCamoTime = 10.00f;
        StatsManager.Instance.globalHealth = 30;
        StatsManager.Instance.globalSpeed = 40;
        StatsManager.Instance.globalAttackDamage = 1;
        StatsManager.Instance.globalKnockBack = 1f;
        StatsManager.Instance.globalIsDead = false;
        StatsManager.Instance.gameHasStarted = true;
        StatsManager.Instance.globalTimer = 180;
        StatsManager.Instance.globalScore = 0;
        SceneManager.LoadScene("MainMap");
    }
}
