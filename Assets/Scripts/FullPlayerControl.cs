using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FullPlayerControl : MonoBehaviour
{
    public GameObject player;

    public GameObject playerCamo;

    public PlayerStats statsPlayer;

    public PlayerStats statsPlayerCamo;

    public bool isCurrentlyCamo = false;

    public bool canCurrentlyCamo = true;

    void Start()
    {
        // Initially start in Anya state
        player.SetActive(true);
        playerCamo.SetActive(false);
    }


    void Update()
    {
        if (PauseMenu.isPaused) return;

        // if Player has no camo time left, lock them out of Camo ability
        if (statsPlayer.camoTime <= 0f)
        {
            statsPlayer.camoTime = 0f;
            canCurrentlyCamo = false;
        }
        else
        {
            canCurrentlyCamo = true;
        }

        // When player is camo
        if (isCurrentlyCamo)
        {
            // Transform location of anya set to current player position
            player.transform.position = playerCamo.transform.position;
            // If player has camo ability time left
            if (canCurrentlyCamo)
            {
                // Allow option to switch back
                if (Input.GetKeyDown(KeyCode.P))
                {
                    showPlayer();
                }
            }
            // If player has no camo ability time left
            else
            {
                // force switch back to regular anya
                showPlayer();
            }
        }
        // When player is anya
        else if (!isCurrentlyCamo)
        {
            // Transform location of camo set to anya position
            playerCamo.transform.position = player.transform.position;
            // If player has camo ability time left
            if (canCurrentlyCamo)
            {
                // option to switch to camo
                if (Input.GetKeyDown(KeyCode.K))
                {
                    showCamo();
                }
            }
            // If no camo abliity time left, there is no option to camo
            else
            {
                return;
            }
            
        }

    }

    public void showCamo()
    {
        // If player switches to camo, all player stats are transfered over immediately
        statsPlayerCamo.camoTime = statsPlayer.camoTime;
        statsPlayerCamo.health = statsPlayer.health;
        statsPlayerCamo.speed = statsPlayer.speed;
        statsPlayerCamo.attackDamage = statsPlayer.attackDamage;
        statsPlayerCamo.knockBack = statsPlayer.knockBack;
        statsPlayerCamo.isDead = statsPlayer.isDead;
        player.SetActive(false);
        playerCamo.SetActive(true);
        isCurrentlyCamo = true;
    }

    public void showPlayer()
    {
        // If player switches to camo, only camoTime stat is transfered.
        // Because this is the only stat that changes during when player uses camo.
        statsPlayer.camoTime = statsPlayerCamo.camoTime;
        player.SetActive(true);
        playerCamo.SetActive(false);
        isCurrentlyCamo = false;
    }
}
