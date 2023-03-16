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
    public GameObject bgm;
    public GameObject pauseButton;
    public GameObject starDisplay;

    public Slider slider;
    public Camera mainCam;

    public void QuitInvoke()
    {
        pauseScreen.SetActive(false);
        leaveScreen.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void Stay()
    {
        pauseScreen.SetActive(true);
        leaveScreen.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void Quit()
    {
        leaveScreen.SetActive(false);
        StartCoroutine(LoadSceneAsync());
        Time.timeScale = 1;
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
        
        loadingScreen.SetActive(true);

        catModel.SetActive(false);
        bgm.SetActive(false);
        pauseButton.SetActive(false);
        starDisplay.SetActive(false);
        



        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progressValue;

            yield return null;
        }
    }
}

