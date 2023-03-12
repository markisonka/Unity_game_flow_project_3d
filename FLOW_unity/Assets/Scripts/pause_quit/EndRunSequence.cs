using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRunSequence : MonoBehaviour
{
    public GameObject liveStars;
    public GameObject liveDis;
    public GameObject endScreen;

    void Start()
    {
        StartCoroutine(EndSequence());
    }

    IEnumerator EndSequence()
    {
        yield return new WaitForSeconds(2);
        liveStars.SetActive(false);
        liveDis.SetActive(false);
        endScreen.SetActive(true);

        Time.timeScale = 0f;
    }
}
