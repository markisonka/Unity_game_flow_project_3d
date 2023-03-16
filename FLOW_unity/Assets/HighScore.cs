using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;

    void Start()
    {
        UpdateHighScoreText();
    }

    void Update()
    {
        UpdateHighScoreText();
    }

    void UpdateHighScoreText()
    {
        highScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }
}
