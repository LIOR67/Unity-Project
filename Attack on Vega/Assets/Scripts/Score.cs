using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    int score;
    TMP_Text ScoreText;
    private void Start()
    {
        ScoreText = GetComponent<TMP_Text>();
        ScoreText.text = "0";

    }
    public void IncreaseScore(int IncreaseAmount)
    {
        score =score+IncreaseAmount;
        ScoreText.text = score.ToString();
    }


}
