using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    void Start()
    {
        Score.totalScore -= Score.instanceScore;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
    
