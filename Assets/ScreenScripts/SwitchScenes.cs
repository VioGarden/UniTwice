using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    // Scene or room to switch to
    public int sceneBuildIndex;

    public PlayerStats stats;

    [Header("Loading Screen")]
    [SerializeField] private GameObject loadingScreen;

    [Header("Slider")]
    [SerializeField] private Slider loadingSlider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with door");
        if (collision.gameObject.name == "Player")
        {

            // Load next scene
            loadingScreen.SetActive(true);
            StartCoroutine(LoadGameAsync(sceneBuildIndex));

        }
    }

    IEnumerator LoadGameAsync(int sceneToLoad)
    {
        AsyncOperation loadOpertation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!loadOpertation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOpertation.progress / 0.9f);
            loadingSlider.value = progressValue;
            yield return null;
        }
    }
}
