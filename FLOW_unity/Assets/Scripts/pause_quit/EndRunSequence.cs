using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRunSequence : MonoBehaviour
{
    public GameObject endScreen;

    void Start()
    {
        StartCoroutine(EndSequence());
    }

    IEnumerator EndSequence()
    {
        yield return new WaitForSeconds(0);
        endScreen.SetActive(true);

        Time.timeScale = 0f;
    }
}
