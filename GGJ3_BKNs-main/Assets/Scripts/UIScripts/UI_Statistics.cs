using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Statistics : MonoBehaviour
{
    public TextMeshProUGUI HighScoreText;
    public TextMeshProUGUI LongestTimeText;

    void OnEnable()
    {
        HighScoreText.text = "HighScore : " + FindObjectOfType<DataHolder>().currentData._highScore;
        LongestTimeText.text = "Longest Time Survived : " + (int)FindObjectOfType<DataHolder>().currentData._longestTimeSurvived;
    }
}
