using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
//public class PlayerEnemyCollision : Simulation.Event<PlayerEnemyCollision>
public class Score : MonoBehaviour
{
    public static int totalScore;
    public static int instanceScore;

    public static int firstZone = 0; //İlk bölümün skoru
    public static int secondZone = 0; // İkinci bölümün skoru
    public static int thirdZone = 0; // Üçüncü bölümün skoru

    public TextMeshProUGUI totalText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI firstZoneScore;
    public TextMeshProUGUI secondZoneScore;
    public TextMeshProUGUI thirdZoneScore;


    void Awake() // Başlayınca skor 0 yap
    {
        instanceScore = 0;
    }
    void Update() // Anlık skoru güncelle
    {
        scoreText.text = "Score: " + instanceScore;
    }

    void OnValidate() //Değer değişikliği yaşandığında skorları yazıya geçir
    {
        totalText.text = "Max Total: " + totalScore;

        try
        {
            firstZoneScore.text = "Max Score: " + firstZone;
            secondZoneScore.text = "Max Score: " + secondZone;
            thirdZoneScore.text = "Max Score: " + thirdZone;
        }
        catch (NullReferenceException)
        {
            Debug.Log("No problem");
        }
    }
}