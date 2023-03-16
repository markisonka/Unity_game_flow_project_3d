using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    private Score ScoreText;
    public AudioClip collectClip;
    public AudioSource AppleSource;
    private bool isActive = true;
    private void Start()
    {
        //Ищем объект ScoreText
        AppleSource = GetComponent<AudioSource>();
        ScoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Score>();
    }

    private void Update()
    {
        gameObject.transform.Rotate(0, 0, 0.5f); //Яблоко крутится
        if (!AppleSource.isPlaying && !isActive)
            this.gameObject.SetActive(false);
    }

    //При касании яблока
    private void OnTriggerEnter(Collider other)
    {
        if (isActive)
        {
            ScoreText.ScorePlusOne(); //увеличиваем счет
            AppleSource.PlayOneShot(collectClip);
        }
        isActive = false;
    }
}
