using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.EventSystem;

public class PauseRunSequence : MonoBehaviour
{
    public GameObject pauseScreen;

    public void PauseInvoke()
    {
        StartCoroutine(PauseSequence());
        Time.timeScale = 0f;
    }


    private IEnumerator PauseSequence()
    {
        yield return new WaitForSeconds(0);
        pauseScreen.SetActive(true);
    }
}
