using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitScene : MonoBehaviour
{
    public GameObject leaveScreen;
    public GameObject pauseScreen;


    public GameObject loadingScreen;
    public GameObject catModel;
    public GameObject decorations;
    public GameObject bgm;
    public GameObject light;
    public GameObject footPath;
    public GameObject hearts;
    public GameObject pauseButton;
    public GameObject starDisplay;
    public GameObject distanceDisplay;
    public GameObject x2Picture;

    public Slider slider;
    public Camera mainCam;

    public void QuitInvoke()
    {
        pauseScreen.SetActive(false);
        leaveScreen.SetActive(true);
    }

    public void Stay()
    {
        pauseScreen.SetActive(true);
        leaveScreen.SetActive(false);
    }

    public void Quit()
    {
        StartCoroutine(LoadSceneAsync());
        Time.timeScale = 1;
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);

        loadingScreen.SetActive(true);

        catModel.SetActive(false);
        decorations.SetActive(false);
        bgm.SetActive(false);
        light.SetActive(false);
        footPath.SetActive(false);
        hearts.SetActive(false);
        pauseButton.SetActive(false);
        starDisplay.SetActive(false);
        distanceDisplay.SetActive(false);
        x2Picture.SetActive(false);

        

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progressValue;

            yield return null;
        }
    }
}

