using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score = 0;
    public Text scoreText;

    public static void updateScore()
    {
        score++;
    }
    public static void resetScore()
    {
        score = 0;
    }
    private void LateUpdate()
    {
        scoreText.text = "Score: " + score;
    }
}
