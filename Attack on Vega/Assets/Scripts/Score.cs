using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int score;
  public void IncreaseScore(int IncreaseAmount)
    {
        score =score+IncreaseAmount;
        Debug.Log(score);
    }


}
