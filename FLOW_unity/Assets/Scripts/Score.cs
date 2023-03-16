using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{
    int ScoreInt;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    //Прибавляем 1 к счёту
    public void ScorePlusOne()
    {
        ScoreInt++;
        CheckHighScore();
    }
    //Меняем текст счёта
    private void Update()
    {
        ScoreText.text ="Score: " + ScoreInt.ToString();
        CheckHighScore();
    }
    void CheckHighScore()
    {
        if (ScoreInt > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", ScoreInt);
        }
        UpdateHighScoreText();
    }

    void UpdateHighScoreText()
    {
        highScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }
}
