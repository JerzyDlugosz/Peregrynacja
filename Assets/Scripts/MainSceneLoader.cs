using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneLoader : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI loadingText;
    [SerializeField]
    private TextMeshProUGUI currentLoadingText;
    [SerializeField]
    private Slider loadingSlider;

    private int currentDots = 0;
    private string dots = "";

    private void Start()
    {
        StartCoroutine(LoadMainSceneAsync());
        InvokeRepeating("DoTheDotDotDot", 0f, 1f);
    }

    IEnumerator LoadMainSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(2);

        asyncLoad.completed += OnAsyncLoadComplete =>
        {
            loadingText.text = "Done!";
            RemoveDotInvoke();
        };

        while (!asyncLoad.isDone)
        {
            loadingSlider.value = asyncLoad.progress;
            yield return null;
        }
    }

    private void DoTheDotDotDot()
    {
        loadingText.text = "Loading" + dots;
        currentDots++;
        dots += ".";
        if (currentDots > 3)
        {
            currentDots = 0;
            dots = "";
        }
        Debug.Log("Still invoked");
    }

    void RemoveDotInvoke()
    {
        CancelInvoke("DoTheDotDotDot");
        Debug.Log("Canceled Invoke on DoTheDotDotDot");
    }
}