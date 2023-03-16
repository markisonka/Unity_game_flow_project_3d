using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeScene : MonoBehaviour
{
    public GameObject pauseScreen;
    public void ResumeTheGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }
}
