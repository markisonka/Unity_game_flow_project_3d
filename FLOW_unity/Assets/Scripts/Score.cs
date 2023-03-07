using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int ScoreInt;
    public Text ScoreText;
    //Прибавляем 1 к счёту
    public void ScorePlusOne()
    {
        ScoreInt++;
    }
    //Меняем текст счёта
    private void Update()
    {
        ScoreText.text = ScoreInt.ToString();
    }
}
