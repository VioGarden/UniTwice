using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    [Header("Menu Screens")]
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject mainMenu;

    [Header("Slider")]
    [SerializeField] private Slider loadingSlider;

    public void Awake()
    {
        mainMenu.SetActive(true);
        loadingScreen.SetActive(false);
    }

    public void LoadGameButton(string thingToLoad)
    {
        mainMenu.SetActive(false);
        loadingScreen.SetActive(true);

        StartCoroutine(LoadGameAsync(thingToLoad));
    }

    IEnumerator LoadGameAsync(string thingToLoad)
    {
        AsyncOperation loadOpertation = SceneManager.LoadSceneAsync(thingToLoad);
        while (!loadOpertation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOpertation.progress / 0.9f);
            loadingSlider.value = progressValue;
            yield return null;
        }
    }
}
