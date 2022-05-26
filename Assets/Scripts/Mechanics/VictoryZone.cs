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
                var ev = Schedule<PlayerEnteredVictoryZone>();//VictoryZone girişi çalıştır, (Ana ekrana gönderme ve skorları kayıt etme)
                ev.victoryZone = this;
            }else if (Input.GetButton("Vertical") && SceneManager.GetActiveScene().buildIndex == 3 && Keys.key3)
            {
                var ev = Schedule<PlayerEnteredVictoryZone>();//VictoryZone girişi çalıştır, (Ana ekrana gönderme ve skorları kayıt etme)
                ev.victoryZone = this;
            }
        }
    }
}