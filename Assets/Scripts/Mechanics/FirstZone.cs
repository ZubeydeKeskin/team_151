using Platformer.Gameplay;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// FirstZone'u başlatır, birinci seviyeye geçer. + Baslangic ekranını başlatır
    /// </summary>
    
    public class FirstZone : MonoBehaviour
    {
        //public TextMeshProUGUI bolum1Score;
        private void OnTriggerStay2D(Collider2D collider)
        {
            if (Input.GetButton("Vertical") && Keys.key1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        
        //Baslangic ekranında oyunu başlatmak için gerekli olan next() fonksiyonu
        public void next()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}