using System;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;
using UnityEngine.SceneManagement;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Marks a trigger as a VictoryZone, usually used to end the current game level.
    /// </summary>
    public class VictoryZone : MonoBehaviour
    {
        private void OnTriggerStay2D(Collider2D collider)
        {
            if (Input.GetButton("Vertical") && SceneManager.GetActiveScene().buildIndex == 2 && Keys.key2)
            {
                var ev = Schedule<PlayerEnteredVictoryZone>();//VictoryZone girişi çalıştır, (Ana ekrana gönder ve skorları kayıt et)
                ev.victoryZone = this;
            }else if (Input.GetButton("Vertical") && SceneManager.GetActiveScene().buildIndex == 3 && Keys.key3)
            {
                var ev = Schedule<PlayerEnteredVictoryZone>();//VictoryZone girişi çalıştır, (Ana ekrana gönder ve skorları kayıt et)
                ev.victoryZone = this;
            }else if (Input.GetButton("Vertical") && SceneManager.GetActiveScene().buildIndex == 4 && Keys.kaykay)
            {
                var ev = Schedule<PlayerEnteredVictoryZone>();//VictoryZone girişi çalıştır, (Son ekrana gönder ve skorları kayıt et)
                ev.victoryZone = this;
            }
        }
    }
}