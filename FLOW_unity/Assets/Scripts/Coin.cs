using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    private Score ScoreText;

    private void Start()
    {
        //Ищем объект ScoreText
        ScoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Score>();
    }

    private void Update()
    {
        gameObject.transform.Rotate(0, 0, 0.5f); //Яблоко крутится
    }

    //При касании яблока
    private void OnTriggerEnter(Collider other)
    { 
        ScoreText.ScorePlusOne(); //увеличиваем счет
        Destroy(gameObject); //уничтожаем яблоко
    }
}
