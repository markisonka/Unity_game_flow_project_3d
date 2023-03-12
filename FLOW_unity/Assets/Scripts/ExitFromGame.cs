using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitFromGame : MonoBehaviour
{
    public GameObject quitTheGame;
    public GameObject gamePlayer;

    public void QuitScreenInvoke()
    {
        gamePlayer.SetActive(false);
        quitTheGame.SetActive(true);
    }

    public void QuitGame()
    {
        #if UNITY_STANDALONE
            Application.Quit();
        #endif
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void StayInGame()
    {
        gamePlayer.SetActive(true);
        quitTheGame.SetActive(false);
    }
}
