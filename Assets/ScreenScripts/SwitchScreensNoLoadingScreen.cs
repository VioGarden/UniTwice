using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchScenesNoLoadingScreen : MonoBehaviour
{
    // Scene or room to switch to
    public int sceneBuildIndex;

    public PlayerStats stats;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with door");
        if (collision.gameObject.name == "Player")
        {

            // Load next scene
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);

        }
    }
}