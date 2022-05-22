using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int totalScore;
    public static int instanceScore;
    public TextMeshProUGUI totalText;
    public TextMeshProUGUI scoreText;
    void Awake()
    {
        instanceScore = 0;
    }
    void Update()
    {
        totalText.text = "Total: " + totalScore;
        scoreText.text = "Score: " + instanceScore;
    }
}
